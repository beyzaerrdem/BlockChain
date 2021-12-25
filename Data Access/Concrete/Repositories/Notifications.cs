namespace Data_Access.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notifications
    {
        [Key]
        public int NotificationId { get; set; }

        [StringLength(500)]
        public string PublicKey { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public virtual Users Users { get; set; }
    }
}
