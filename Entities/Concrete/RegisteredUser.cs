using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }

        public byte[] HashValue { get; set; }
    }
}
