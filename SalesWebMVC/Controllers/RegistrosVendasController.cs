using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class RegistrosVendasController : Controller
    {
        private readonly RegistroVendasService _salesRecordService;

        public RegistrosVendasController(RegistroVendasService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BuscaSimplesAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;
            }

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyyy-MM-dd");

            var resultado = await _salesRecordService.BuscaPorDataAsync(dataInicial, dataFinal);
            return View(resultado);
        }
        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}
