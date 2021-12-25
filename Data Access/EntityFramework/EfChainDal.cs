using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Data_Access.Abstract;
using Data_Access.Concrete;
using Entities.Dto;

namespace Data_Access.EntityFramework
{
    public class EfChainDal : IChainDal
    {

        public List<PostDto> GetAllPostDtos()
        {
            using (SqlConnection connection = AdoNetConnection.getDbInstance().GetDBConnection())
            {
                string query = "SELECT * from PostView";
                var command = new SqlCommand(query, connection);
                var postDtos = new List<PostDto>();

                try
                {
                    command.Connection.Open();

                    using (SqlDataReader dr = command.ExecuteReader())

                    {
                        while (dr.Read())
                        {
                            PostDto postDto = new PostDto 
                            {
                                Post = (string)dr["post"],
                                ProfilPhoto = (string)dr["ProfilPhoto"],
                                Timestamp = (long)dr["Timestamp"],
                                UserName = (string)dr["UserName"]
                            };
                            postDtos.Add(postDto);
                        }

                    }

                    return postDtos;

                }
                catch (SqlException ex)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}