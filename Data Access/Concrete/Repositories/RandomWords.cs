namespace Data_Access.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RandomWords
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Word { get; set; }
    }
}
