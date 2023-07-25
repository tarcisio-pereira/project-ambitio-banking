using System;
using ambitio_banking.Helpers;
using ambitio_banking.Models;
using ambitio_banking.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ambitio_banking.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepository usuarioRespository,
                               ISessao sessao,
                               IEmail email)
        {
            _usuarioRepository = usuarioRespository;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            // Se o usuário estiver logado redirecionar para a tela inicial
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
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
                            _sessao.CriarSessaoDoUsuario(usuario);
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

        [HttpPost]

        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Ambitio Banking Redefinir Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepository.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Uma nova senha foi enviado para o email cadastrado.";
                            return RedirectToAction("Index", "Login");
                        } else
                        {
                            TempData["MensagemErro"] = $"Erro, email não foi enviado. Por favor tente novamente!";
                            return RedirectToAction("Index", "Login");
                        }
                    }
                    TempData["MensagemErro"] = $"Não foi possível redefinir sua senha. Por favor verifique os dados informado!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops... não foi possível redefinir sua senha. Tente novamente! detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}