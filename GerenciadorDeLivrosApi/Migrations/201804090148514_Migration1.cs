namespace GerenciadorDeLivrosApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livroes", "Editores", c => c.String(maxLength: 100));
            AlterColumn("dbo.Livroes", "Titulo", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Livroes", "SubTitulo", c => c.String(maxLength: 40));
            AlterColumn("dbo.Livroes", "Editora", c => c.String(maxLength: 40));
            AlterColumn("dbo.Livroes", "NumeroEdicao", c => c.String(maxLength: 10));
            AlterColumn("dbo.Livroes", "AnoPublicacao", c => c.String(maxLength: 10));
            AlterColumn("dbo.Livroes", "Resenha", c => c.String(maxLength: 100));
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Usuarios", "PassWord", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "PassWord", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Livroes", "Resenha", c => c.String());
            AlterColumn("dbo.Livroes", "AnoPublicacao", c => c.String());
            AlterColumn("dbo.Livroes", "NumeroEdicao", c => c.String());
            AlterColumn("dbo.Livroes", "Editora", c => c.String());
            AlterColumn("dbo.Livroes", "SubTitulo", c => c.String());
            AlterColumn("dbo.Livroes", "Titulo", c => c.String());
            AlterColumn("dbo.Livroes", "Editores", c => c.String());
        }
    }
}
