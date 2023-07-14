﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ambitio_banking.Models;
using ambitio_banking.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ambitio_banking.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<UsuarioModel>  usuarios = _usuarioRepository.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _usuarioRepository.Adicionar(usuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            _usuarioRepository.Atualizar(usuario);
            return RedirectToAction("Index");
        }
    }
}

