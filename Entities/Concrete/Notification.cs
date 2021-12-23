using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("User")]
        public string PublicKey { get; set; }
        public virtual User User { get; set; }

        [StringLength(500)]
        public string Message { get; set; }
    }
}
