using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket_Gestiune.Models.Data_Access_Layer
{
    internal class CategoriiDAL
    {

        public ObservableCollection<Categorii> GetAllCategories()
        {
            ObservableCollection<Categorii> categoryList = new ObservableCollection<Categorii>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Categorii where esteActiva = 1;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Categorii categorii = new Categorii
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        EsteActiva = reader.GetBoolean(2)
                    };
                    categoryList.Add(categorii);
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
            return categoryList;
        }

        public bool AddCategory (Categorii categorii)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaCategorie", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@nume", categorii.Nume);

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

        public bool DeleteCategory(Categorii categorii) 
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("StergeCategorie", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@categorieID", categorii.Id);

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

        public bool UpdateCategory(Categorii categorii)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("UpdateCategorie", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@categorieID", categorii.Id);
                com.Parameters.AddWithValue("@numeCategorie", categorii.Nume);

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
                SqlCommand com = new SqlCommand("GetCategorieIDdupaNume", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numeCategorie", name);

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

        public float SumaPreturilorPerCategorie(Categorii categorii)
        {
            float suma = 0;
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("SumaPreturilorDeVanzarePeCategorie", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@categorieID", categorii.Id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    suma = (float)reader.GetDecimal(0);
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
            return suma;
        }

    }
}
