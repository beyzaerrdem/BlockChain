namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        BlockId = c.Int(nullable: false, identity: true),
                        PreviousHash = c.String(),
                        Hash = c.String(),
                        Nonce = c.Long(nullable: false),
                        Timestamp = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BlockId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        PostOwnerId = c.String(maxLength: 500),
                        BlockId = c.Int(nullable: false),
                        Post = c.String(),
                        Signature = c.String(),
                        Timestamp = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Blocks", t => t.BlockId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PostOwnerId)
                .Index(t => t.PostOwnerId)
                .Index(t => t.BlockId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikedId = c.Int(nullable: false, identity: true),
                        PublicKey = c.String(maxLength: 500),
                        TransactionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikedId)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PublicKey)
                .Index(t => t.PublicKey)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        PublicKey = c.String(nullable: false, maxLength: 500),
                        UserName = c.String(maxLength: 50),
                        ProfilPhoto = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.PublicKey);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        PublicKey = c.String(maxLength: 500),
                        Message = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Users", t => t.PublicKey)
                .Index(t => t.PublicKey);
            
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
                        HashValue = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
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
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.RandomWords");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Likes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Blocks");
        }
    }
}
