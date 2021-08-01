using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            listaDepartamentos.Add(new Departamento(1, "Eletronicos"));
            listaDepartamentos.Add(new Departamento(2, "Informática"));

            return View(listaDepartamentos);
        }
    }
}
