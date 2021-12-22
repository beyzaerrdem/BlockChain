using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikeService
    {
        List<Like> GetAll();
        Like GetById(int id);
        void Add(Like like);
        void Update(Like like);
        void Delete(Like like);
    }
}
