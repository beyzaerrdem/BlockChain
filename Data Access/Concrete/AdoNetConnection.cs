using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrete
{
    public class AdoNetConnection
    {
        private static AdoNetConnection dbInstance;
        private readonly SqlConnection conn = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=DbBlockChain;integrated security=true;");

        private AdoNetConnection()
        {
        }

        public static AdoNetConnection getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new AdoNetConnection();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
            }
            finally
            {
            }

            return conn;
        }
    }
}
