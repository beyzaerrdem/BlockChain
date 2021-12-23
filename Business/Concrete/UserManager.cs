using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserCheckService _userCheckService;
        public UserManager(IUserDal userDal, IUserCheckService userCheckService)
        {
            _userDal = userDal;
            _userCheckService = userCheckService;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(string id)
        {
            return _userDal.Get(u => u.PublicKey == id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
