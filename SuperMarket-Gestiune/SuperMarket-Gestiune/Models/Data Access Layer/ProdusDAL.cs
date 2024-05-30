using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Gestiune.Models.Data_Access_Layer
{
    internal class ProdusDAL
    {
        public ObservableCollection<Produse> GetAllProducts()
        {
            ObservableCollection<Produse> productList = new ObservableCollection<Produse>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Produse where esteActiva = 1;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Produse produse = new Produse
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        CodBare = reader.GetString(2),
                        CategorieId = reader.GetInt32(3),
                        ProducatorId = reader.GetInt32(4),
                        EsteActiva = reader.GetBoolean(5)
                    };
                    productList.Add(produse);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productList;
        }

        public bool AddProductWithStock(Produse produse , Stocuri stock,string numeCategorie , string NumeProducator)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaProdusCuStoc", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numeProdus", produse.Nume);
                com.Parameters.AddWithValue("@codBare", produse.CodBare);

                CategoriiDAL categoriiDAL = new CategoriiDAL();
                int catID = categoriiDAL.GetIDForName(numeCategorie);

                com.Parameters.AddWithValue("@categorieID", catID);

                ProducatoriDAL producatoriDAL = new ProducatoriDAL();
                int prodID = producatoriDAL.GetIDForName(NumeProducator);

                com.Parameters.AddWithValue("@producatorID", prodID);
                
                com.Parameters.AddWithValue("@cantitate", stock.Cantitate);
                com.Parameters.AddWithValue("@unitateMasura", stock.UnitateMasura);
                com.Parameters.AddWithValue("@dataAprovizionarii", stock.DataAprovizionarii);
                com.Parameters.AddWithValue("@dataExpirarii", stock.DataExpirarii);
                com.Parameters.AddWithValue("@pretAchizitie", stock.PretAchizitie);

                float pretVanzare = (float)((float)stock.PretAchizitie * 119.00 /100.00);

                com.Parameters.AddWithValue("@pretVanzare", pretVanzare);

                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteProduct(Produse produse)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("StergeProdus", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@produsID", produse.Id);

                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool updateProduct(Produse produse)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("UpdateProdus", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@produsID", produse.Id);
                com.Parameters.AddWithValue("@numeProdus", produse.Nume);
                com.Parameters.AddWithValue("@codBare", produse.CodBare);
                com.Parameters.AddWithValue("@categorieID", produse.CategorieId);
                com.Parameters.AddWithValue("@producatorID", produse.ProducatorId);

                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetIDForName(string name)
        {
            int ID = 0;
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("GetProdusIDDupaNume", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numeProdus", name);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ID;
        }

        public ObservableCollection<Produse> GetProductsForProducers(Producatori producatori)
        {
            ObservableCollection<Produse> productList = new ObservableCollection<Produse>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("GetProduseDupaProducatorID",con);
                com.CommandType = CommandType.StoredProcedure;

                ProducatoriDAL producatoriDAL = new ProducatoriDAL();
                int id = producatoriDAL.GetIDForName(producatori.Nume);

                com.Parameters.AddWithValue("@producatorID", id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Produse produse = new Produse
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        CodBare = reader.GetString(2),
                        CategorieId = reader.GetInt32(3),
                        ProducatorId = reader.GetInt32(4),
                        EsteActiva = reader.GetBoolean(5)
                    };
                    productList.Add(produse);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productList;
        }

        public float GetPriceForProduct(Produse produs)
        {
            float price=0.0f;
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("GetPretVanzarePrimulStoc", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@produsID", produs.Id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    price = (float)reader.GetDecimal(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return price;
        }

        public ObservableCollection<Produse> GetAllForCategory(string categoryName)
        {
            ObservableCollection<Produse> productList = new ObservableCollection<Produse>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Produse where esteActiva = 1 and categorie_id = @id ;";

                CategoriiDAL categoriiDAL = new CategoriiDAL();
                int id = categoriiDAL.GetIDForName(categoryName);

                com.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Produse produse = new Produse
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        CodBare = reader.GetString(2),
                        CategorieId = reader.GetInt32(3),
                        ProducatorId = reader.GetInt32(4),
                        EsteActiva = reader.GetBoolean(5)
                    };
                    productList.Add(produse);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productList;
        }

        public ObservableCollection<Produse> GetProductsForName(string productName)
        {
            ObservableCollection<Produse> productList = new ObservableCollection<Produse>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Produse where esteActiva = 1 and nume like '%' + @string + '%' ;";

                com.Parameters.AddWithValue("@string", productName);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Produse produse = new Produse
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        CodBare = reader.GetString(2),
                        CategorieId = reader.GetInt32(3),
                        ProducatorId = reader.GetInt32(4),
                        EsteActiva = reader.GetBoolean(5)
                    };
                    productList.Add(produse);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productList;
        }

        public ObservableCollection<Produse> GetProductsForBarCode(string barcode)
        {
            ObservableCollection<Produse> productList = new ObservableCollection<Produse>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Produse where esteActiva = 1 and cod_bare like '%' + @string + '%' ;";

                com.Parameters.AddWithValue("@string", barcode);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Produse produse = new Produse
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        CodBare = reader.GetString(2),
                        CategorieId = reader.GetInt32(3),
                        ProducatorId = reader.GetInt32(4),
                        EsteActiva = reader.GetBoolean(5)
                    };
                    productList.Add(produse);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productList;
        }

    }
}
