using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SinemaOtomasyonuStaj.DataAcces
{
    class DbConnection
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=True;MultipleActiveResultSets=True");
  
        public static void Connect()
        {
            if(conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
         
        }
        public static void Disconnect()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
           
        }

    }
}
    

