using System;
using System.ComponentModel.DataAnnotations;
using ambitio_banking.Enum;

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
        [EmailAddress(ErrorMessage ="Email Invalido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Perfil obrigatório")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}