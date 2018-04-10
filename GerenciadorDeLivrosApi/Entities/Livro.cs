using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GerenciadorDeLivrosApi.Utils;
using System.Linq;
using System.Web;

namespace GerenciadorDeLivrosApi.Models
{
	public class Livro
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(100)]
		public string Editores { get; set;}
		[MaxLength(40)]
		[Required]
		public string Titulo{get;set;}
		[MaxLength(40)]
		public string SubTitulo { get; set;}
		[MaxLength(40)]
		public string Editora{get;set;}
		[MaxLength(10)]
		public string NumeroEdicao{get;set;}
		[MaxLength(10)]
		public string AnoPublicacao{get;set;}
		[MaxLength(100)]
		public string Resenha{get;set;}
		[Required]
		public int NumeroExemplares{get;set;}
		public int Isbn { get; set;}
		public int QtdPaginas { get; set; }

		[Required]
		public DateTime DataInclusao { get; set; }
		public DateTime DataAlteracao { get; set; }
		[Required]
		public Enums.Status Status { get; set; }

		[ForeignKey("Genero")]
		public int GeneroId { get; set; }
		public Genero Genero { get; set;}

		[ForeignKey("Usuario")]
		public int Livro_UsuarioCri { get; set; }
		public Usuario Usuario { get; set; }








	}
}