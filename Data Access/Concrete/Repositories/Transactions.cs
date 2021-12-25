namespace Data_Access.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transactions()
        {
            Likes = new HashSet<Likes>();
        }

        [Key]
        public int TransactionId { get; set; }

        public int BlockId { get; set; }

        public string Post { get; set; }

        public string Signature { get; set; }

        public long Timestamp { get; set; }

        [StringLength(500)]
        public string PostOwnerId { get; set; }

        public virtual Blocks Blocks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }

        public virtual Users Users { get; set; }
    }
}
