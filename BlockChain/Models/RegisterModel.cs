using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockChain.Models
{
    public class RegisterModel
    {
        public long NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string UserName { get; set; }
    }
}