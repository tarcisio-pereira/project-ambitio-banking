using System;
namespace ambitio_banking.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string? Cpf { get; set; }
		public string? Senha { get; set; }
        public DateTime  Datacadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}

