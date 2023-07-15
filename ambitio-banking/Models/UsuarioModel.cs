using System;
using System.ComponentModel.DataAnnotations;
using ambitio_banking.Enum;

namespace ambitio_banking.Models
{
	public class UsuarioModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage ="Email Invalido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Senha { get; set; }
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
	}
}