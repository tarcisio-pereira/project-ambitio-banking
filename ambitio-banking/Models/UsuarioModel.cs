using System;
using System.ComponentModel.DataAnnotations;
using ambitio_banking.Enum;
using ambitio_banking.Helpers;

namespace ambitio_banking.Models
{
	public class UsuarioModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage ="Email Inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Perfil obrigatório")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public virtual ContaBancariaModel ContaBancaria { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 6);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}