namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_postApi_storedProcedure : DbMigration
    {
        public override void Up()
        {
            Sql("sp_configure 'show advanced options', 1;\r\nGO\r\nRECONFIGURE;\r\nGO\r\nsp_configure 'Ole Automation Procedures', 1;\r\nGO\r\nRECONFIGURE;\r\nGO");
            CreateStoredProcedure("apiPost",p=>new {path=p.String(),Body=p.String(),Response=p.String(outParameter:true)},body:"" +
                                                           "DECLARE @URL NVARCHAR(MAX) = 'http://localhost:8081/api/'+@path;\r\nDECLARE @Object AS INT;\r\nDECLARE @ResponseText AS VARCHAR(8000);\r\nEXEC sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;\r\nEXEC sp_OAMethod @Object, 'open', NULL, 'post',\r\n                 @URL,\r\n                 'false'\r\nEXEC sp_OAMethod @Object, 'setRequestHeader', null, 'Content-Type', 'application/json'\r\nEXEC sp_OAMethod @Object, 'send', null, @body\r\nEXEC sp_OAMethod @Object, 'responseText', @ResponseText OUTPUT\r\nEXEC sp_OADestroy @Object\r\nIF CHARINDEX('false',(SELECT @ResponseText)) > 0\r\nBEGIN\r\n RETURN 0\r\nEND\r\nELSE\r\nBEGIN\r\n select @Response=@ResponseText\r\n RETURN 1\r\nEND");
        }
        
        public override void Down()
        {
            DropStoredProcedure("apiPost");
        }
    }
}
