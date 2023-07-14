using System;
using ambitio_banking.Enum;

namespace ambitio_banking.Models
{
	public class UsuarioModel
	{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        
	}
}