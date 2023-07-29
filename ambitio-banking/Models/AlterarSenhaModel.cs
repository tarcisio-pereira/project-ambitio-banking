using System;
using System.ComponentModel.DataAnnotations;

namespace ambitio_banking.Models
{
	public class AlterarSenhaModel
	{
        public int Id { get; set;}

        [Required(ErrorMessage ="Digite a senha atual")] 
		public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Digite a nova senha novamente")]
        [Compare("NovaSenha", ErrorMessage ="Senha digitada é diferente da nova senha")]
        public string ConfirmarNovaSenha { get; set; }

    }
}