﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class RegistrosVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuscaSimples()
        {
            return View();
        }
        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}