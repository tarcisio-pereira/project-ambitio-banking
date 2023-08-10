using System;
using MySqlX.XDevAPI;

namespace ambitio_banking.Models
{
	public class ContaBancariaModel
	{
        public int Id { get; set; }
        public int? NumeroConta { get; set; }
        public decimal? Saldo { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }       
    }
}

