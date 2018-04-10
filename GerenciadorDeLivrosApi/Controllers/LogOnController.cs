using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using GerenciadorDeLivrosApi.Models;
using GerenciadorDeLivrosApi.Utils;
using System.Web.Script.Serialization;

namespace GerenciadorDeLivrosApi.Controllers
{
	public class LogOnController : Controller
	{
		// GET: LogOn
		public ActionResult Index(string Search = "")
		{
			List<Livro> livros = new List<Livro>();
			using (BookContext bd = new BookContext())
			{

				var result = Search == "" ? (from livro in bd.Livros
											 join genero in bd.Generos on livro.GeneroId equals genero.Id
											 select new { Livro = livro, Genero = genero })
							 : (from livro in bd.Livros
								join genero in bd.Generos on livro.GeneroId equals genero.Id
								where (livro.Titulo.Contains(Search))
								select new { Livro = livro, Genero = genero })
							 ;
				////var result = bd.Livros.Where(x => x.Status == Enums.Status.Ativo);
				foreach (var objeto in result)
				{
					objeto.Livro.Genero = objeto.Genero;

					livros.Add(objeto.Livro);

				}
			}

			ViewBag.Title = "Home";
			return View(livros);
		}
		[HttpGet]
		public ActionResult EditBook()
		{
			ViewBag.Title = "Cadastro Livro";
			ViewBag.Generos = new List<Genero>();
			using (BookContext bd = new BookContext())
			{
				var result = bd.Generos;
				foreach (var genero in result)
				{
					((List<Genero>)(ViewBag.Generos)).Add(genero);
				}
			}
			return View(new Livro());
		}
		[HttpGet]
		public ActionResult EditGenero()
		{
			ViewBag.Title = "Cadastro Generos";
			return View(new Genero());
		}
		[HttpGet]
		public ActionResult EditGeneros(int Id)
		{
			ViewBag.Title = "Edição Generos";
			Genero genero = new Genero();
			using (BookContext bd = new BookContext())
			{
				genero = (Genero)bd.Generos.Where(x => x.Id == Id).First();
			}
				return View("EditGenero",genero);
		}
		[HttpPost]
		public ActionResult RegisterGenero(Genero genero)
		{
			using (BookContext bd = new BookContext())
			{
				genero.DataInclusao = DateTime.Now;
				genero.DataAlteracao = DateTime.Now;
				genero.Genero_UsuarioCri = ((Usuario)(Session["User"])).Id;
				bd.Generos.Add(genero);
				bd.SaveChanges();
			}
			return RedirectToAction("EditGenero"); ;
		}
		[HttpPost]
		public ActionResult SaveGenero(Genero genero)
		{
			using (BookContext bd = new BookContext())
			{
				genero.DataAlteracao = DateTime.Now;
				genero.Genero_UsuarioCri = ((Usuario)(Session["User"])).Id;
				bd.Generos.Attach(genero);
				var entry = bd.Entry(genero);
				entry.Property(e => e.DataAlteracao).IsModified = true;
				entry.Property(e => e.Genero_UsuarioCri).IsModified = true;
				entry.Property(e => e.Descricao).IsModified = true;
				bd.SaveChanges();
			}
			return EditGeneros(genero.Id);
		}

		[HttpGet]
		public ActionResult EditBooks(int id)
		{
			ViewBag.Title = "Edição Livro";
			ViewBag.Generos = new List<Genero>();
			Livro livro = new Livro();
			using (BookContext bd = new BookContext())
			{
				var result = bd.Generos;
				foreach (var genero in result)
				{
					((List<Genero>)(ViewBag.Generos)).Add(genero);
				}
				var results = from livros in bd.Livros
							  join genero in bd.Generos on livros.GeneroId equals genero.Id
							  where (livros.Id == id)
							  select new { Livro = livros, Genero = genero };
				////var result = bd.Livros.Where(x => x.Status == Enums.Status.Ativo);
				foreach (var objeto in results)
				{
					objeto.Livro.Genero = objeto.Genero;
					livro = objeto.Livro;
				}
			}
			return View("EditBook", livro);
		}

		[HttpPost]
		public ActionResult RegisterBook(Livro livro)
		{
			using (BookContext bd = new BookContext())
			{
				livro.DataInclusao = DateTime.Now;
				livro.DataAlteracao = DateTime.Now;
				livro.Status = Enums.Status.Ativo;
				livro.Livro_UsuarioCri = ((Usuario)(Session["User"])).Id;
				bd.Livros.Add(livro);
				bd.SaveChanges();
			}
			return RedirectToAction("EditBook");
		}
		[HttpPost]
		public ActionResult SaveBook(Livro livro)
		{
			using (BookContext bd = new BookContext())
			{
				livro.DataAlteracao = DateTime.Now;
				livro.Livro_UsuarioCri = ((Usuario)(Session["User"])).Id;
				bd.Livros.Attach(livro);
				var entry = bd.Entry(livro);
				entry.Property(e => e.Isbn).IsModified = true;
				entry.Property(e => e.Livro_UsuarioCri).IsModified = true;
				entry.Property(e => e.NumeroEdicao).IsModified = true;
				entry.Property(e => e.NumeroExemplares).IsModified = true;
				entry.Property(e => e.QtdPaginas).IsModified = true;
				entry.Property(e => e.Resenha).IsModified = true;
				entry.Property(e => e.SubTitulo).IsModified = true;
				entry.Property(e => e.Titulo).IsModified = true;
				entry.Property(e => e.DataAlteracao).IsModified = true;
				entry.Property(e => e.AnoPublicacao).IsModified = true;
				entry.Property(e => e.Editora).IsModified = true;
				entry.Property(e => e.Editores).IsModified = true;
				entry.Property(e => e.GeneroId).IsModified = true;
				bd.SaveChanges();
			}
			return EditBooks(livro.Id);
		}
		[HttpGet]
		public ActionResult DeleteBook(int id)
		{
			using (BookContext bd = new BookContext())
			{
				var Livro = (Livro)bd.Livros.Where(x => x.Id == id).First();
				bd.Entry(Livro).State = System.Data.Entity.EntityState.Deleted;
				bd.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}