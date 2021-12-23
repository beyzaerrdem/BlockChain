namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updated_tc_hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "HashValue", c => c.Binary());
            DropColumn("dbo.RegisteredUsers", "Tc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisteredUsers", "Tc", c => c.Long(nullable: false));
            DropColumn("dbo.RegisteredUsers", "HashValue");
        }
    }
}
