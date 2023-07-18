using System;
using ambitio_banking.Models;
using ambitio_banking.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ambitio_banking.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRespository)
        {
            _usuarioRepository = usuarioRespository; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.BuscarPorCpf(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Tente novamente!";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Tente novamente!";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops... não conseguimos realizar seu login, tente novamente! detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}