using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GerenciadorDeLivrosApi.Models;
namespace GerenciadorDeLivrosApi.Utils
{
	public class AuthenticationHandler : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			var key = filterContext.HttpContext.Request.QueryString["Home"];
			Usuario user = filterContext.HttpContext.Session["User"] != null
				? (Usuario)filterContext.HttpContext.Session["User"]
				: null;

			if (filterContext.HttpContext.Request.Url.ToString().IndexOf("LogOn") != -1 && !IsValid(user))
			{
				// Unauthorized!
				filterContext.Result = new HttpUnauthorizedResult();
			}
			//else if(filterContext.HttpContext.Request.Url.ToString().IndexOf("Home") != -1 && IsValid(user))
			//{
			//	filterContext.HttpContext.Request.Url
			//}
		}

		private bool IsValid(Usuario user)
		{
			if(user != null)
			{
				using (BookContext bd = new BookContext())
				{
					var resultado = bd.Usuarios.Where(p => p.Login == user.Login && p.PassWord == user.PassWord);
					foreach (var usuario in resultado)
					{
						return usuario.Id > 0 && user.Status == Enums.Status.Ativo;
					}
				}
			}
			return false;


		}


	}
}