using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentoService(SalesWebMVCContext context)
        {
            _context = context;
        }

        /* Implementação Assincrona usando Task*/
        public async Task<List<Departamento>> LocalizarTodosAsync()
        {
            return await _context.Departamento.OrderBy(d => d.NomeDepartamento).ToListAsync();
        }

        /*Implementação Sincrona*/
        /*public List<Departamento> LocalizarTodos()
        {
            return _context.Departamento.OrderBy(d => d.NomeDepartamento).ToList();
        }*/
    }
}
