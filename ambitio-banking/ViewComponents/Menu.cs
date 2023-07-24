using System;
using ambitio_banking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ambitio_banking.ViewComponents
{
	public class Menu : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

			if (string.IsNullOrEmpty(sessaoUsuario)) return null;

			UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

			return View(usuario);
		}
	}
}