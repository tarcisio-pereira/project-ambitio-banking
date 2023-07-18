using System;
using System.ComponentModel.DataAnnotations;

namespace ambitio_banking.Models
{
	public class LoginModel
	{
            [Required(ErrorMessage = "Campo Obrigatório")]
			public string? Login { get; set; }
            [Required(ErrorMessage = "Senha obrigatória")]
            public string? Senha { get; set; }
	}
}