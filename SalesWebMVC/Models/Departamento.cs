using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nomeDepartamento)
        {
            Id = id;
            NomeDepartamento = nomeDepartamento;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public void RemoverVendedor(Vendedor vendedor)
        {
            Vendedores.Remove(vendedor);
        }

        public double TotalVendasDepartamento(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendedores.Sum(vendedores => vendedores.TotalVendas(dataInicial, dataFinal));
        }
    }
}
