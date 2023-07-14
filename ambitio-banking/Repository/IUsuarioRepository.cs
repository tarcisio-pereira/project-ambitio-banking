using System;
using ambitio_banking.Models;

namespace ambitio_banking.Repository
{
	public interface IUsuarioRepository
	{
		List<UsuarioModel> BuscarTodos();

		UsuarioModel Adicionar(UsuarioModel usuario);
	}
}

