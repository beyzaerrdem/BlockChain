using System.Collections.Generic;
using System.Linq;
using Data_Access.Abstract;
using Data_Access.Concrete;
using Entities.Dto;

namespace Data_Access.EntityFramework
{
    public class EfChainDal:IChainDal
    {
        public List<PostDto> GetAllPostDtos()
        {
            using (var db =new Context())
            {
                return db.PostView.ToList();
            }
        }
    }
}