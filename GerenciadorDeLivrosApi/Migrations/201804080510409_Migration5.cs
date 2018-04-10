namespace GerenciadorDeLivrosApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Descricao", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Usuarios", "PassWord", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "PassWord", c => c.String());
            AlterColumn("dbo.Usuarios", "Login", c => c.String());
            AlterColumn("dbo.Usuarios", "Descricao", c => c.String());
        }
    }
}
