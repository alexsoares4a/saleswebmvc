using SalesWebMVC.Data;
using SalesWebMVC.Models;
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
        public List<Vendedor> LocalizarTodos()
        {
            //acessa a tabela de vendedores, converte em uma lista e retorna
            //a lista com os registros
            return _context.Vendedor.ToList();
        }

        public void Cadastrar(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor LocalizarPorId(int id)
        {
            return _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
    }
}
