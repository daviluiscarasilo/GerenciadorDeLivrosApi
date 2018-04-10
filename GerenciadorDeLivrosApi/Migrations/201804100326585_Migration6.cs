namespace GerenciadorDeLivrosApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Generoes", "Descricao", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Generoes", "Descricao", c => c.String());
        }
    }
}
