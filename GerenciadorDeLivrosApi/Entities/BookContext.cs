namespace GerenciadorDeLivrosApi.Models
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class BookContext : DbContext
	{
		public BookContext()
			: base("name=BookContext")
		{
		}

		public DbSet<Livro> Livros { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

	}


}