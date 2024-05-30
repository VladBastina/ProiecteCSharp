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
    internal class DetaliiBonuriDAL
    {

        public ObservableCollection<DetaliiBonuri> GetDetailsForBon(Bonuri bonuri)
        {
            ObservableCollection<DetaliiBonuri> detaliiBonuri = new ObservableCollection<DetaliiBonuri>();
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * from DetaliiBonuri where bon_id = @id ;";

                com.Parameters.AddWithValue("@id",bonuri.Id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetaliiBonuri p = new DetaliiBonuri
                    {
                        Id = reader.GetInt32(0),
                        BonId = reader.GetInt32(1),
                        ProdusId = reader.GetInt32(2),
                        Cantitate = reader.GetDecimal(3),
                        Subtotal = (float)reader.GetDecimal(4),
                        EsteActiva = reader.GetBoolean(5),
                    };
                    detaliiBonuri.Add(p);
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
            return detaliiBonuri;
        }

    }
}
