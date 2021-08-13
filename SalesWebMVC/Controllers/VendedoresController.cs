using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /*Método Assíncrono*/
        public async Task<IActionResult> Index()
        {
            var listaVendedores = await _vendedorService.LocalizarTodosAsync();
            return View(listaVendedores);
        }

        /*Método Síncrono*/
        /*public IActionResult Index()
        {
            var listaVendedores = _vendedorService.LocalizarTodos();
            return View(listaVendedores);
        }*/

        public async Task<IActionResult> Cadastrar()
        {
            var departamentos = await _departamentoService.LocalizarTodosAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.LocalizarTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorService.CadastrarAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var obj = await _vendedorService.LocalizarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _vendedorService.ExcluirAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var obj = await _vendedorService.LocalizarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var obj = await _vendedorService.LocalizarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            List<Departamento> departamentos = await _departamentoService.LocalizarTodosAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.LocalizarTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde." });
            }

            try
            {
                await _vendedorService.AtualizarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
