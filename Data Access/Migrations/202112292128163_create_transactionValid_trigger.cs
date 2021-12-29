namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_transactionValid_trigger : DbMigration
    {
        public override void Up()
        {
            Sql("create trigger transactionValidation\r\non [Transactions]\r\nafter insert,update\r\nas\r\nbegin\r\n\r\nDeclare @PostOwnerId nvarchar(500)\r\nDeclare @Post nvarchar(MAX) \r\nDeclare @Signature nvarchar(MAX)\r\nDeclare @Timestamp nvarchar(max)\r\nselect @PostOwnerId=PostOwnerId,@Post=Post,@Signature=Signature,@Timestamp=CAST(Timestamp as varchar(max)) from inserted\r\nDeclare @json nvarchar(max) ='{\"data\":{\"postOwnerId\":\"'+@PostOwnerId+'\",\"post\":\"'+@Post+'\",\"signature\":\"'+@Signature+'\",\"timestamp\":'+@Timestamp+'}}'\r\ndeclare @responsevalue nvarchar(max)\r\nexecute apiPost\r\n\t\t@path='transaction/isvalid',\r\n\t\t@Body=@json,\r\n\t\t@Response=@responsevalue output\r\n\r\nprint @responsevalue\r\nif @responsevalue='true'\r\nbegin\r\nrollback transaction\r\nend\r\nelse\r\nbegin\r\nrollback transaction\r\nend\r\nend");
        }
        
        public override void Down()
        {
            Sql("drop trigger transactionValidation");
        }
    }
}
