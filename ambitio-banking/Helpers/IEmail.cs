using System;
namespace ambitio_banking.Helpers
{
	public interface IEmail
	{

		bool Enviar(string email, string assunto, string mensagem);
	}
}

