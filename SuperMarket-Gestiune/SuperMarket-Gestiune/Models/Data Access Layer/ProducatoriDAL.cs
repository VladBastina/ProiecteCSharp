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
    internal class ProducatoriDAL
    {
        public ObservableCollection<Producatori> GetAllProducatori()
        {
            ObservableCollection<Producatori> producatoriList = new ObservableCollection<Producatori>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Producatori where esteActiva = 1;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Producatori producator = new Producatori
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        TaraOrigine = reader.GetString(2),
                        EsteActiva = reader.GetBoolean(3)
                    };
                    producatoriList.Add(producator);
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

            return producatoriList;
        }

        public bool AddProducator(Producatori producatori)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaProducator", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numeProducator", producatori.Nume);
                com.Parameters.AddWithValue("@taraOrigine", producatori.TaraOrigine);

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

        public bool DeleteProducator(Producatori producatori)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("StergeProducator", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@producatorID", producatori.Id);

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

        public bool UpdateUser(Producatori producatori)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("UpdateProducator", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@producatorID", producatori.Id);
                com.Parameters.AddWithValue("@numeProducator", producatori.Nume);
                com.Parameters.AddWithValue("@taraOrigine", producatori.TaraOrigine);

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
            int ID=0;
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("GetProducatorIDdupaNume", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numeProducator", name);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                if(reader.Read())
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

    }
}
