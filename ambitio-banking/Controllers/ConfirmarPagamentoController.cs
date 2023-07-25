using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ambitio_banking.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ambitio_banking.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ConfirmarPagamentoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}