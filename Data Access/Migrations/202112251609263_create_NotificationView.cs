namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_NotificationView : DbMigration
    {
        public override void Up()
        {
           // Sql("Create view NotificationView \r\nas\r\nSELECT dbo.Notifications.Message, dbo.Users.UserName, dbo.Users.ProfilPhoto\r\nFROM     dbo.Notifications INNER JOIN\r\n                  dbo.Users ON dbo.Notifications.PublicKey = dbo.Users.PublicKey");
        }
        
        public override void Down()
        {
            //Sql("drop view NotificationView");
        }
    }
}
