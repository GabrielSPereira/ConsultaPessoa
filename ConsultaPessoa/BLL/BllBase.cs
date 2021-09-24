using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa.Models
{
    public class BllBase
    {
        public static SqlConnection db;

        public BllBase()
        {
            try
            {
                string strConn = "Data Source=DESKTOP-JEI16TC\\SQLEXPRESS;Initial Catalog=BD_DISTRIBUIDORA;Integrated Security=true";
                db = new SqlConnection(strConn);
                db.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}