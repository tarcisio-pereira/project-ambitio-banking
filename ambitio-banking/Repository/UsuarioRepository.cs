using System;
using ambitio_banking.Data;
using ambitio_banking.Models;

namespace ambitio_banking.Repository
{
	public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AmbitioContext _ambitioContext;
        private object usuarioDB;

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
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
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
            usuarioDB.DataAtualizacao = DateTime.Now;
            usuario.SetSenhaHash();
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

        public UsuarioModel BuscarPorCpf(string Cpf)
        {
            return _ambitioContext.Usuario.FirstOrDefault(x => x.Cpf == Cpf);
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string Cpf)
        {
            return _ambitioContext.Usuario.FirstOrDefault(x => x.Cpf == Cpf && x.Email.ToUpper() == email.ToUpper());
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro ao atualizar a senha, usuário não encontrado!");
            if (usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha altual incorreta");
            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("A nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _ambitioContext.Usuario.Update(usuarioDB);
            _ambitioContext.SaveChanges();

            return usuarioDB;
        }
    }
}