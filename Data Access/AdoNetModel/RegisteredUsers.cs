namespace Data_Access.AdoNetModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisteredUsers
    {
        public int Id { get; set; }

        public byte[] HashValue { get; set; }
    }
}
