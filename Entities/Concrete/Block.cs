using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }

        public string PreviousHash { get; set; }

        public string Hash { get; set; }

        [Column(TypeName = "bigint")]
        public int Nonce { get; set; }

        [Column(TypeName = "bigint")]
        public int Timestamp { get; set; }
    }
}
