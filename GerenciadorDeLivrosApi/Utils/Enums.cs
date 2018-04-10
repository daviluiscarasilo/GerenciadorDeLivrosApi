using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorDeLivrosApi.Utils
{
	public class Enums
	{
		public enum UserPermission
		{
			Administrator = 1,
			ReadOnly = 2	
		}
		public enum Status
		{
			Ativo = 1,
			Inativo = 0
		}

	}
}