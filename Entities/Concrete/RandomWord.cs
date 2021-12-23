using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RandomWord
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Word { get; set; }
    }
}
