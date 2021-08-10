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

        public void Cadastrar(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }
    }
}
