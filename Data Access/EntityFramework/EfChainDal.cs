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
           
            return new AdoNet().GetResult<PostDto>("select * from PostView");
        }
    }
}
