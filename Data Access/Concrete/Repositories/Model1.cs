using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data_Access.Concrete.Repositories
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<RandomWords> RandomWords { get; set; }
        public virtual DbSet<RegisteredUsers> RegisteredUsers { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<PostView> PostView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.PostOwnerId);
        }
    }
}
