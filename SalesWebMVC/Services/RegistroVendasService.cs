using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class RegistroVendasService
    {
        private readonly SalesWebMVCContext _context;

        public RegistroVendasService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> BuscaPorDataAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = from obj in _context.RegistroVendas select obj;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(x => x.DataVenda >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(x => x.DataVenda <= dataFinal.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataVenda)
                .ToListAsync();
        }
    }
}
