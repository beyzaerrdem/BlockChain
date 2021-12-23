using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [StringLength(500)]
        [ForeignKey("PostOwner")]
        public string PostOwnerId { get; set; }
        public virtual User PostOwner { get; set; }

        [ForeignKey("Block")]
        public int BlockId { get; set; }
        public virtual Block Block { get; set; }

        public string Post { get; set; }

        public string Signature { get; set; }

        [Column(TypeName = "bigint")]
        public long Timestamp { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
