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
    internal class StocuriDAL
    {
        public ObservableCollection<Stocuri> GetAllStocks()
        {
            ObservableCollection<Stocuri> stocuri = new ObservableCollection<Stocuri>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Stocuri where esteActiva = 1;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Stocuri st = new Stocuri
                    {
                        Id=reader.GetInt32(0),
                        ProdusId=reader.GetInt32(1),
                        Cantitate = reader.GetDecimal(2),
                        UnitateMasura = reader.GetString(3),
                        DataAprovizionarii = reader.GetDateTime(4),
                        DataExpirarii = reader.GetDateTime(5),
                        PretAchizitie = (float) reader.GetDecimal(6),
                        PretVanzare = (float) reader.GetDecimal(7),
                        EsteActiva = reader.GetBoolean(8)
                    };
                    stocuri.Add(st);
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
            return stocuri;
        }

        public bool AdaugaStock(Stocuri st,string NumeProdus)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaStoc", con);
                com.CommandType = CommandType.StoredProcedure;

                ProdusDAL produs = new ProdusDAL();
                int prdID = produs.GetIDForName(NumeProdus);

                com.Parameters.AddWithValue("@produsID", prdID);
                com.Parameters.AddWithValue("@cantitate",st.Cantitate);
                com.Parameters.AddWithValue("@unitateMasura", st.UnitateMasura);
                com.Parameters.AddWithValue("@dataAprovizionarii", st.DataAprovizionarii);
                com.Parameters.AddWithValue("@dataExpirarii", st.DataExpirarii);
                com.Parameters.AddWithValue("@pretAchizitie", st.PretAchizitie);

                float pretVanzare = (float)((float)st.PretAchizitie * 119.00 / 100.00);

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

        public bool DeleteStock(Stocuri stoc)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("StergeStoc", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@stocID", stoc.Id);

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

        public bool UpdatePriceForStock(Stocuri stoc)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("ModificaPretVanzare", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@stocID",stoc.Id);
                com.Parameters.AddWithValue("@noulPretVanzare", stoc.PretVanzare);

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
    }
}
