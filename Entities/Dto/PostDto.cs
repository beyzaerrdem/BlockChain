using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Dto
{
    [Table("PostView")]
    public class PostDto 
    {
        public string Post { get; set; }
        public string UserName { get; set; }
        public string ProfilPhoto { get; set; }
        public long Timestamp { get; set; }
        public DateTime PostTime => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}