using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciadorDeLivrosApi.Models
{
	public class Genero
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(50)]
		public string Descricao { get; set;}
		public DateTime DataInclusao { get; set; }
		public DateTime DataAlteracao { get; set; }

		[ForeignKey("GeneroId")]
		public ICollection<Livro> Livros { get; set; }

		[ForeignKey("Usuario")]
		public int Genero_UsuarioCri { get; set; }
		public Usuario Usuario { get; set; }


	}
}