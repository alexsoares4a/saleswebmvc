using Microsoft.AspNetCore.Mvc;
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

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var listaVendedores = _vendedorService.LocalizarTodos();
            return View(listaVendedores);
        }
    }
}
