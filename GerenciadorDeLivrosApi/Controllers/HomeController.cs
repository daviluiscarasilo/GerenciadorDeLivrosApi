using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GerenciadorDeLivrosApi.Models;

namespace GerenciadorDeLivrosApi.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if(Session["User"] != null && ((Usuario) (Session["User"])).Status == Utils.Enums.Status.Ativo)
			{
				return RedirectToAction("Index", "LogOn");
			}
			else
			{
				ViewBag.Title = "Entrar no Gerenciador de Livros";
				return View();
			}
		}
		[HttpPost]
		public ActionResult LogIn(string Nome, string Senha)
		{
			using (BookContext bd = new BookContext())
			{
				var resultado = bd.Usuarios.Where(p => p.Login == Nome && p.PassWord == Senha);
				foreach (var usuario in resultado)
				{
					Session["User"] = usuario;
					return RedirectToAction("Index", "LogOn");
				}
			}
			return RedirectToAction("Index");

		}
		[HttpGet]
		public ActionResult LogOff()
		{
			Session["User"] = null;
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit()
		{
			ViewBag.Title = "Cadastro Usuários";
			return View();
		} 

		[HttpPost]
		public ActionResult Register(string Descricao,string Nome, string Senha)
		{
			using (BookContext bd = new BookContext())
			{
				Usuario user = new Usuario(Descricao,Nome,Senha,Utils.Enums.UserPermission.Administrator,Utils.Enums.Status.Ativo);
				bd.Usuarios.Add(user);
				bd.SaveChanges();
			}
				return PartialView("Index");
		}
	}
}
