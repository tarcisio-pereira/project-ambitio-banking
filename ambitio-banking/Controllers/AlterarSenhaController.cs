using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ambitio_banking.Helpers;
using ambitio_banking.Models;
using ambitio_banking.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ambitio_banking.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepository usuarioRepository,
                                      ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao= sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Senha não foi alterada, tente novamente! Detalhes do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}

