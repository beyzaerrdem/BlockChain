namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_postView : DbMigration
    {
        public override void Up()
        {
            Sql("create view PostView as\r\nSELECT dbo.Transactions.Post, dbo.Users.UserName, dbo.Users.ProfilPhoto, dbo.Transactions.Timestamp\r\nFROM     dbo.Transactions INNER JOIN\r\n                  dbo.Users ON dbo.Transactions.PostOwnerId = dbo.Users.PublicKey");
        }
        
        public override void Down()
        {
            Sql("drop view PostView");
        }
    }
}
