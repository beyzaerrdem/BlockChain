namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_block : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blocks");
        }
    }
}
