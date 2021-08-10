using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        //declarar uma dependencia para VendedorService
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var listaVendedores = _vendedorService.LocalizarTodos();
            return View(listaVendedores);
        }

        public IActionResult Cadastrar()
        {
            var departamentos = _departamentoService.LocalizarTodos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            _vendedorService.Cadastrar(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
