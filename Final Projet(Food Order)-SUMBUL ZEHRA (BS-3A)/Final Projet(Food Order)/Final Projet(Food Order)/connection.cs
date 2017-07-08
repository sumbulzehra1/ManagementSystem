using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Final_Projet_Food_Order_
{
    public class connect
    {
       public SqlConnection conn = new SqlConnection();
        public void connstring()
        {
            conn.ConnectionString = @"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|food_sys.mdf;Database=food_sys;
Trusted_Connection=Yes;";
        }
        
    }
}
