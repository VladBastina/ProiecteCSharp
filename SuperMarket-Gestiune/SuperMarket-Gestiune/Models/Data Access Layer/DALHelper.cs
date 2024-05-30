using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Gestiune.Models.Data_Access_Layer
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SuperMarketContext"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
