using System;
using ambitio_banking.Data;
using ambitio_banking.Models;

namespace ambitio_banking.Repository
{
	public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AmbitioContext _ambitioContext;

        public UsuarioRepository(AmbitioContext ambitoContext)
        {

            _ambitioContext = ambitoContext;

        }

        public UsuarioModel ListarPorId(int id)
        {
            return _ambitioContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _ambitioContext.Usuario.ToList();
        }


        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _ambitioContext.Usuario.Add(usuario);
            _ambitioContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Cpf = usuario.Cpf;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Senha = usuario.Senha;

            _ambitioContext.Usuario.Update(usuarioDB);
            _ambitioContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar( int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro ao apagar o contato!");

            _ambitioContext.Usuario.Remove(usuarioDB);
            _ambitioContext.SaveChanges();

            return true;

        }
    }
}

