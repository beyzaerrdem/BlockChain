using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegisteredUserService
    {
        List<RegisteredUser> GetAll();
        bool IsUserExist(byte[] hash);
        RegisteredUser GetById(int id);
        void Add(RegisteredUser registeredUser);
        void Update(RegisteredUser registeredUser);
        void Delete(RegisteredUser registeredUser);
    }
}
