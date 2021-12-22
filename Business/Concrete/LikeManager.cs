using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;

        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public void Add(Like like)
        {
            _likeDal.Add(like);
        }

        public void Delete(Like like)
        {
            _likeDal.Delete(like);
        }

        public List<Like> GetAll()
        {
            return _likeDal.GetAll();
        }

        public Like GetById(int id)
        {
            return _likeDal.Get(l => l.LikedId == id);
        }

        public void Update(Like like)
        {
            _likeDal.Update(like);
        }
    }
}
