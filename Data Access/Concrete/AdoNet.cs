using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access.Concrete
{
    public class AdoNet
    {
        private readonly string _conString= ConfigurationManager.ConnectionStrings["connString"].ToString();
        
        public List<T> GetResult<T>(string query) where T : new()
        {
            using (var connection = new SqlConnection(_conString))
            {
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = connection;
                    var result = new List<T>();
                    if (!ConnectionOpen(cmd.Connection)) return result;
                    using (var dr = cmd.ExecuteReader())
                    {
                        
                        var properties = typeof(T).GetProperties();
            
                        while (dr.Read())
                        {
                            var entity = new T();
                            foreach (var property in properties)
                            {
                                try
                                {
                                    property.SetValue(entity, dr[property.Name]);
                                }
                                catch (Exception)
                                {
                                    // ignored
                                }
                            }
                            result.Add(entity);
                        }
                        ConnectionClose(cmd.Connection);
                        return result;
                    }
                }
            }
        }


        private bool ConnectionOpen(IDbConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void ConnectionClose(IDbConnection connection)
        {
            connection.Close();
        }
    }
}