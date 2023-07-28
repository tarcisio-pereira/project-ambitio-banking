using System;
using ambitio_banking.Models;

namespace ambitio_banking.Repository
{
	public interface IUsuarioRepository
	{
		UsuarioModel BuscarPorCpf(string Cpf);

        UsuarioModel BuscarPorEmailELogin(string email ,string Cpf);

        UsuarioModel ListarPorId(int id);

		List<UsuarioModel> BuscarTodos();

		UsuarioModel Adicionar(UsuarioModel usuario);

		UsuarioModel Atualizar(UsuarioModel usuario);

		UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);

		bool Apagar(int id);
	}
}

