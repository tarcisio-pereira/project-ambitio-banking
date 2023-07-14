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

        public List<UsuarioModel> BuscarTodos()
        {
            return _ambitioContext.ToList();
        }


        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _ambitioContext.Usuario.Add(usuario);
            _ambitioContext.SaveChanges();
            return usuario;
        }

    }
}

