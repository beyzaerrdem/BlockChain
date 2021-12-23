using Business.Abstract;
using Business.Adapters;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserCheckManager : IUserCheckService
    {
        public bool CheckIfRealPerson(UserValidationDto userValidationDto)
        {
            return MernisServiceAdapter.CheckIfRealPerson(userValidationDto);    
        }
    }
}
