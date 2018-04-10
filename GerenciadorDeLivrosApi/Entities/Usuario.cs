using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GerenciadorDeLivrosApi.Utils;
using System.Linq;
using System.Web;

namespace GerenciadorDeLivrosApi.Models
{
	public class Usuario
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(40)]
		[Required]
		public string Descricao { get; set; }
		[MaxLength(40)]
		[Required]
		public string Login { get; set; }
		[MaxLength(40)]
		[Required]
		public string PassWord { get; set; }

		[Required]
		public Enums.UserPermission Permission{get;set;}
		[Required]
		public Enums.Status Status { get; set; }

		////Livros
		//[ForeignKey("UsuarioAlt")]
		//public ICollection<Livro> LivrosAlt { get; set; }

		[ForeignKey("Livro_UsuarioCri")]
		public ICollection<Livro> Livros { get; set; }

		////Generos
		//[ForeignKey("UsuarioAlt")]
		//public ICollection<Genero> GenerosAlt { get; set; }

		[ForeignKey("Genero_UsuarioCri")]
		public ICollection<Genero> Generos { get; set; }


		public Usuario() {
			Generos = new List<Genero>();
			Livros = new List<Livro>();
		}

		public Usuario(string Descricao, string Login,string PassWord, Enums.UserPermission Permission, Enums.Status Status)
		{
			this.Descricao = Descricao;
			this.Login = Login;
			this.PassWord = PassWord;
			this.Permission = Permission;
			this.Status = Status;
		}

	}
}