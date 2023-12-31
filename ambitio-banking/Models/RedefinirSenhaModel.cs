﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ambitio_banking.Models
{
	public class RedefinirSenhaModel
	{
        [Required(ErrorMessage = "Login obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }
    }
}

