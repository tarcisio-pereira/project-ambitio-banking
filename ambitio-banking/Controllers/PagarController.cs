using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ambitio_banking.Filters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ambitio_banking.Controllers
{
    [PaginaParaUsuarioLogado]
    public class PagarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

