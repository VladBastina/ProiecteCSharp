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
    internal class UtilizatoriDAL
    {
        public ObservableCollection<Utilizatori> GetAllUsers()
        {
            ObservableCollection<Utilizatori> utilizatoriList = new ObservableCollection<Utilizatori>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Utilizatori where esteActiva = 1;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Utilizatori utilizator = new Utilizatori
                    {
                        // Assuming columns are Id, Nume, Prenume, Email and EsteActiva
                        Id = reader.GetInt32(0),
                        NumeUtilizator = reader.GetString(1),
                        Parola = reader.GetString(2),
                        TipUtilizator = reader.GetString(3),
                        EsteActiva = reader.GetBoolean(4)
                    };
                    utilizatoriList.Add(utilizator);
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

            return utilizatoriList;
        }

        public bool AddUser(Utilizatori user)
        {
                SqlConnection con = DALHelper.Connection;
                try
                {
                    SqlCommand com = new SqlCommand("AdaugaUtilizator", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@numeUtilizator", user.NumeUtilizator);
                    com.Parameters.AddWithValue("@parola", user.Parola);
                    com.Parameters.AddWithValue("@tipUtilizator", user.TipUtilizator);

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

        public bool DeleteUser(Utilizatori user)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("StergeUtilizator", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@utilizatorID",user.Id);

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

        public bool UpdateUser(Utilizatori user)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("UpdateUtilizator", con);
                com.CommandType = CommandType.StoredProcedure;

                // Adding parameters for the stored procedure
                com.Parameters.AddWithValue("@utilizatorID", user.Id);
                com.Parameters.AddWithValue("@numeUtilizator", user.NumeUtilizator);
                com.Parameters.AddWithValue("@parola", user.Parola);
                com.Parameters.AddWithValue("@tipUtilizator", user.TipUtilizator);

                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
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
