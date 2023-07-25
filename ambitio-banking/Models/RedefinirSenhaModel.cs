using System;
using System.ComponentModel.DataAnnotations;

namespace ambitio_banking.Models
{
	public class RedefinirSenhaModel
	{
        [Required(ErrorMessage = "Login Obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email obrigatória")]
        public string Email { get; set; }
    }
}

