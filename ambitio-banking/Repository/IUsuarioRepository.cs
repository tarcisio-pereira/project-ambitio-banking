using System;
using ambitio_banking.Models;

namespace ambitio_banking.Repository
{
	public interface IUsuarioRepository
	{
		UsuarioModel BuscarPorCpf(string Cpf);

		UsuarioModel ListarPorId(int id);

		List<UsuarioModel> BuscarTodos();

		UsuarioModel Adicionar(UsuarioModel usuario);

		UsuarioModel Atualizar(UsuarioModel usuario);

		bool Apagar(int id);
	}
}

