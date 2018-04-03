using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Rifa.DAL
{
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["RIFA"].ConnectionString);
            con.Open();
        }

        protected void CloseConnection()
        {
            con.Close();
        }
    }
}
