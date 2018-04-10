namespace GerenciadorDeLivrosApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Login = c.String(),
                        PassWord = c.String(),
                        Permission = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Generoes", "DataInclusao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Generoes", "DataAlteracao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Generoes", "Genero_UsuarioCri", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "Editores", c => c.String());
            AddColumn("dbo.Livroes", "SubTitulo", c => c.String());
            AddColumn("dbo.Livroes", "NumeroEdicao", c => c.String());
            AddColumn("dbo.Livroes", "Isbn", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "QtdPaginas", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "Livro_UsuarioCri", c => c.Int(nullable: false));
            CreateIndex("dbo.Generoes", "Genero_UsuarioCri");
            CreateIndex("dbo.Livroes", "Livro_UsuarioCri");
            AddForeignKey("dbo.Livroes", "Livro_UsuarioCri", "dbo.Usuarios", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Generoes", "Genero_UsuarioCri", "dbo.Usuarios", "Id", cascadeDelete: false);
            DropColumn("dbo.Livroes", "Edicao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livroes", "Edicao", c => c.String());
            DropForeignKey("dbo.Generoes", "Genero_UsuarioCri", "dbo.Usuarios");
            DropForeignKey("dbo.Livroes", "Livro_UsuarioCri", "dbo.Usuarios");
            DropIndex("dbo.Livroes", new[] { "Livro_UsuarioCri" });
            DropIndex("dbo.Generoes", new[] { "Genero_UsuarioCri" });
            DropColumn("dbo.Livroes", "Livro_UsuarioCri");
            DropColumn("dbo.Livroes", "Status");
            DropColumn("dbo.Livroes", "QtdPaginas");
            DropColumn("dbo.Livroes", "Isbn");
            DropColumn("dbo.Livroes", "NumeroEdicao");
            DropColumn("dbo.Livroes", "SubTitulo");
            DropColumn("dbo.Livroes", "Editores");
            DropColumn("dbo.Generoes", "Genero_UsuarioCri");
            DropColumn("dbo.Generoes", "DataAlteracao");
            DropColumn("dbo.Generoes", "DataInclusao");
            DropTable("dbo.Usuarios");
        }
    }
}
