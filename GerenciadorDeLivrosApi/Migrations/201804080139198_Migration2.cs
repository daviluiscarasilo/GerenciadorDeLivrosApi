namespace GerenciadorDeLivrosApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Livroes", "DataInclusao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Livroes", "DataAlteracao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Livroes", "GeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Livroes", "GeneroId");
            AddForeignKey("dbo.Livroes", "GeneroId", "dbo.Generoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "GeneroId", "dbo.Generoes");
            DropIndex("dbo.Livroes", new[] { "GeneroId" });
            DropColumn("dbo.Livroes", "GeneroId");
            DropColumn("dbo.Livroes", "DataAlteracao");
            DropColumn("dbo.Livroes", "DataInclusao");
            DropTable("dbo.Generoes");
        }
    }
}
