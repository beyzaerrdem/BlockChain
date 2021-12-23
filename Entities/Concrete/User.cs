using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User
    {
        [Key]
        [StringLength(500)]
        public string PublicKey { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string ProfilPhoto { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
