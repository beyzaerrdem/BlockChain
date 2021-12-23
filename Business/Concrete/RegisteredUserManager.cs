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
    public class RegisteredUserManager : IRegisteredUserService
    {
        IRegisteredUserDal _registeredUserDal;

        public RegisteredUserManager(IRegisteredUserDal registeredUserDal)
        {
            _registeredUserDal = registeredUserDal;
        }

        public void Add(RegisteredUser registeredUser)
        {
            _registeredUserDal.Add(registeredUser);
        }

        public bool IsUserExist(byte[] hash)
        {
            return _registeredUserDal.Get(x => x.HashValue == hash) != null;
        }

        public void Delete(RegisteredUser registeredUser)
        {
            _registeredUserDal.Delete(registeredUser);
        }

        public List<RegisteredUser> GetAll()
        {
            return _registeredUserDal.GetAll();
        }

        public RegisteredUser GetById(int id)
        {
            return _registeredUserDal.Get(x => x.Id == id);
        }

        public void Update(RegisteredUser registeredUser)
        {
            _registeredUserDal.Update(registeredUser);
        }
    }
}
