using Microsoft.VisualBasic.ApplicationServices;
using SuperMarket_Gestiune.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperMarket_Gestiune.Models.Data_Access_Layer
{
    internal class BonuriDAL
    {
        public ObservableCollection<Bonuri> GetAllBonuri()
        {
            ObservableCollection<Bonuri> bonuri = new ObservableCollection<Bonuri>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from Bonuri where esteActiva = 1 AND suma_incasata > 0 ;";
                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bonuri bon = new Bonuri 
                    { 
                        Id = reader.GetInt32(0),
                        DataEliberarii = reader.GetDateTime(1),
                        CasierId = reader.GetInt32(2),
                        SumaIncasata = (float)reader.GetDecimal(3),
                        EsteActiva = reader.GetBoolean(4)
                    };
                    bonuri.Add(bon);
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
            return bonuri;
        }

        public Bonuri AddBon(Utilizatori utilizatori)
        {
            Bonuri bonuri = new Bonuri();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaBon", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@dataEliberarii", DateTime.Now);
                com.Parameters.AddWithValue("@casierID", utilizatori.Id);

                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if(reader.Read())
                {
                    bonuri = new Bonuri
                    {
                        Id = (int)reader.GetDecimal(0),
                        DataEliberarii = DateTime.Now,
                        CasierId = utilizatori.Id,
                        SumaIncasata = 0
                    };
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
            return bonuri;
        }


        public ObservableCollection<DateAndSum> GetSumInDates(Utilizatori utilizatori,DateTime date)
        {
            ObservableCollection<DateAndSum> sumAndDates = new ObservableCollection<DateAndSum>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("VizualizareIncasariPeLuna",con);
                com.CommandType= CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@utilizatorID",utilizatori.Id);
                com.Parameters.AddWithValue("@anul",date.Year);
                com.Parameters.AddWithValue("@luna", date.Month);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DateAndSum sum = new DateAndSum()
                    {
                        Date = reader.GetDateTime("Data"),
                        Sum = (float)reader.GetDecimal("SumaIncasata")
                    };
                    sumAndDates.Add(sum);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return sumAndDates;
        }

        public Bonuri GetHighestBon (DateTime date)
        {
            Bonuri bon=new Bonuri();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AfisareCelMaiMareBonAlZilei", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@data", date);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    bon = new Bonuri
                    {
                        Id = reader.GetInt32(0),
                        DataEliberarii = reader.GetDateTime(1),
                        CasierId = reader.GetInt32(2),
                        SumaIncasata = (float)reader.GetDecimal(3),
                        EsteActiva = reader.GetBoolean(4)
                    };
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
            return bon;
        }

        public void AddProductOnBon(DetaliiBonuri detaliiBonuri)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand("AdaugaProdusPeBon", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@bonID", detaliiBonuri.BonId);
                com.Parameters.AddWithValue("@produsID", detaliiBonuri.ProdusId);
                com.Parameters.AddWithValue("@cantitate", detaliiBonuri.Cantitate);

                con.Open();

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
