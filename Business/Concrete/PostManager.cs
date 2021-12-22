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
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void Add(Post post)
        {
            _postDal.Add(post);
        }

        public void Delete(Post post)
        {
            _postDal.Delete(post);
        }

        public List<Post> GetAll()
        {
            return _postDal.GetAll();
        }

        public Post GetById(int id)
        {
            return _postDal.Get(p => p.PostId == id);
        }

        public void Update(Post post)
        {
            _postDal.Update(post);
        }
    }
}
