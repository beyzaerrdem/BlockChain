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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool CheckUserName(string userName)
        {
            var result=_userDal.Get(u => u.UserName == userName);
            return !(result is null);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetUser(string publicKey)
        {
            return _userDal.Get(x => x.PublicKey == publicKey);
        }
    }
}
