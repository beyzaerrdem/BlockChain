using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters
{
    public class MernisServiceAdapter
    {
        public static bool CheckIfRealPerson(UserValidationDto userValidationDto)
        {
            var service = new mernis.KPSPublicSoapClient();
            return service.TCKimlikNoDogrula(
                userValidationDto.NationalatyId,
                userValidationDto.FirstName, userValidationDto.LastName, userValidationDto.BirthYear);
        }
    }
}
