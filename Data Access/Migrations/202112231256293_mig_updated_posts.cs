namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updated_posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RandomWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tc = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Likes", "TransactionId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "PostOwnerId", c => c.String(maxLength: 500));
            AlterColumn("dbo.Notifications", "Message", c => c.String(maxLength: 500));
            CreateIndex("dbo.Transactions", "PostOwnerId");
            CreateIndex("dbo.Transactions", "BlockId");
            CreateIndex("dbo.Likes", "PublicKey");
            CreateIndex("dbo.Likes", "TransactionId");
            CreateIndex("dbo.Notifications", "PublicKey");
            AddForeignKey("dbo.Transactions", "BlockId", "dbo.Blocks", "BlockId", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "TransactionId", "dbo.Transactions", "TransactionId", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "PublicKey", "dbo.Users", "PublicKey");
            AddForeignKey("dbo.Likes", "PublicKey", "dbo.Users", "PublicKey");
            AddForeignKey("dbo.Transactions", "PostOwnerId", "dbo.Users", "PublicKey");
            DropColumn("dbo.Likes", "PostId");
            DropColumn("dbo.Transactions", "PrivateKey");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "PasswordSalt");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PublicKey = c.String(maxLength: 500),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            AddColumn("dbo.Users", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Users", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Transactions", "PrivateKey", c => c.String());
            AddColumn("dbo.Likes", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "PostOwnerId", "dbo.Users");
            DropForeignKey("dbo.Likes", "PublicKey", "dbo.Users");
            DropForeignKey("dbo.Notifications", "PublicKey", "dbo.Users");
            DropForeignKey("dbo.Likes", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "BlockId", "dbo.Blocks");
            DropIndex("dbo.Notifications", new[] { "PublicKey" });
            DropIndex("dbo.Likes", new[] { "TransactionId" });
            DropIndex("dbo.Likes", new[] { "PublicKey" });
            DropIndex("dbo.Transactions", new[] { "BlockId" });
            DropIndex("dbo.Transactions", new[] { "PostOwnerId" });
            AlterColumn("dbo.Notifications", "Message", c => c.String());
            DropColumn("dbo.Transactions", "PostOwnerId");
            DropColumn("dbo.Likes", "TransactionId");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.RandomWords");
        }
    }
}
