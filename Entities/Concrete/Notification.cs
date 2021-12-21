using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [StringLength(500)]
        public string PublicKey { get; set; }

        public string Message { get; set; }
    }
}
