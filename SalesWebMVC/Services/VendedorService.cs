using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class VendedorService
    {
        private readonly SalesWebMVCContext _context;

        //construtor
        public VendedorService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //Operação FindAll
        public async Task<List<Vendedor>> LocalizarTodosAsync()
        {
            //acessa a tabela de vendedores, converte em uma lista e retorna
            //a lista com os registros
            return await _context.Vendedor.ToListAsync();
        }

        public async Task CadastrarAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> LocalizarPorIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("O vendedor não pode ser excluído, pois possui vendas vinculadas.");
            }
        }

        public async Task AtualizarAsync(Vendedor obj)
        {
            if (!await _context.Vendedor.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
