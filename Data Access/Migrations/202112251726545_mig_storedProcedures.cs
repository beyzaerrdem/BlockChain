namespace Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_storedProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("apiPost", p => new { path = p.String(), Body = p.String(), Response = p.String(outParameter: true) }, body: "" +
                                                           "DECLARE @URL NVARCHAR(MAX) = 'http://localhost:8081/api/'+@path;\r\nDECLARE @Object AS INT;\r\nDECLARE @ResponseText AS VARCHAR(8000);\r\nEXEC sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;\r\nEXEC sp_OAMethod @Object, 'open', NULL, 'post',\r\n                 @URL,\r\n                 'false'\r\nEXEC sp_OAMethod @Object, 'setRequestHeader', null, 'Content-Type', 'application/json'\r\nEXEC sp_OAMethod @Object, 'send', null, @body\r\nEXEC sp_OAMethod @Object, 'responseText', @ResponseText OUTPUT\r\nEXEC sp_OADestroy @Object\r\nIF CHARINDEX('false',(SELECT @ResponseText)) > 0\r\nBEGIN\r\n RETURN 0\r\nEND\r\nELSE\r\nBEGIN\r\n select @Response=@ResponseText\r\n RETURN 1\r\nEND");
            CreateStoredProcedure("apiGet", p => new { path = p.String(), Response = p.String(outParameter: true) }, body: "" +
                           "DECLARE @URL NVARCHAR(MAX) = 'http://localhost:8081/api/'+@path;\r\nDeclare @Object as Int;\r\nDeclare @ResponseText as Varchar(8000);\r\n\r\nExec sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;\r\nExec sp_OAMethod @Object, 'open', NULL, 'get',\r\n       @URL,\r\n       'False'\r\nExec sp_OAMethod @Object, 'send'\r\nExec sp_OAMethod @Object, 'responseText', @ResponseText OUTPUT\r\nIF((Select @ResponseText) <> '')\r\nBEGIN\r\n     set @Response=@ResponseText\r\nEND\r\nELSE\r\nBEGIN\r\n     DECLARE @ErroMsg NVARCHAR(30) = 'No data found.';\r\n     Print @ErroMsg;\r\nEND\r\nExec sp_OADestroy @Object\r\n");
        }

        public override void Down()
        {
            DropStoredProcedure("apiPost");
            DropStoredProcedure("apiGet");
        }
    }
}
