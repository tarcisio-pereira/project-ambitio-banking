using System;
using ambitio_banking.Models;

namespace ambitio_banking.Helpers
{
	public interface ISessao
	{

		void CriarSessaoDoUsuario(UsuarioModel usuario);

		void RemoverSessao();

		UsuarioModel BuscarSessaoDoUsuario();

	}
}

