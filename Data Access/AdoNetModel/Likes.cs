namespace Data_Access.AdoNetModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Likes
    {
        [Key]
        public int LikedId { get; set; }

        [StringLength(500)]
        public string PublicKey { get; set; }

        public int TransactionId { get; set; }

        public virtual Transactions Transactions { get; set; }

        public virtual Users Users { get; set; }
    }
}
