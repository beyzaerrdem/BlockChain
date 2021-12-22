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

        public int BlockId { get; set; }

        public string PrivateKey { get; set; }

        public string Post { get; set; }

        public string Signature { get; set; }

        [Column(TypeName = "bigint")]
        public int Timestamp { get; set; }
    }
}
