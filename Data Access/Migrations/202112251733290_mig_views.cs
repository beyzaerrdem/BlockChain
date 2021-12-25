namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_views : DbMigration
    {
        public override void Up()
        {
            Sql("create view PostView as\r\nSELECT dbo.Transactions.Post, dbo.Users.UserName, dbo.Users.ProfilPhoto, dbo.Transactions.Timestamp\r\nFROM     dbo.Transactions INNER JOIN\r\n                  dbo.Users ON dbo.Transactions.PostOwnerId = dbo.Users.PublicKey");
            Sql("Create view NotificationView \r\nas\r\nSELECT dbo.Notifications.Message, dbo.Users.UserName, dbo.Users.ProfilPhoto\r\nFROM     dbo.Notifications INNER JOIN\r\n                  dbo.Users ON dbo.Notifications.PublicKey = dbo.Users.PublicKey");
        }
        
        public override void Down()
        {
            Sql("drop view PostView");
            Sql("drop view NotificationView");
        }
    }
}
