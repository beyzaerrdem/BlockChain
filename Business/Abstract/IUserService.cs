using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetUser(string publicKey);
        bool CheckUserName(string userName);
        void Add(User user);
    }
}
