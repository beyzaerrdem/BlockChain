using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dto;

namespace Data_Access.Concrete
{
    public class Context : DbContext
    {
        public Context() : base("connString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<PostDto>();
            modelBuilder.Ignore<NotificationDto>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<RandomWord> RandomWords { get; set; }
        public DbSet<PostDto> PostView { get; set; }

    }
    public class PostViewConfiguration : EntityTypeConfiguration<PostDto>
    {
        public PostViewConfiguration()
        {
            this.HasKey(t => t.UserName);
            this.ToTable("PostView");
        }
    }
    public class NotificationViewConfiguration : EntityTypeConfiguration<NotificationDto>
    {
        public NotificationViewConfiguration()
        {
            this.HasKey(t => t.UserName);
            this.ToTable("NotificationView");
        }
    }
}
