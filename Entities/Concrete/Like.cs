using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Like
    {
        [Key]
        public int LikedId { get; set; }

        [StringLength(500)]
        public string PublicKey { get; set; }

        public int PostId { get; set; }
    }
}
