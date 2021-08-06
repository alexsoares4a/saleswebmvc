using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }

        public ICollection<RegistroVendas> ListaVendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(string name, string email, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            //Id = id;
            Name = name;
            Email = email;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(RegistroVendas registroVendas)
        {
            ListaVendas.Add(registroVendas);
        }

        public void RemoverVendas(RegistroVendas registroVendas)
        {
            ListaVendas.Remove(registroVendas);
        }

        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {

            return ListaVendas.Where(vendas => vendas.DataVenda >= dataInicial && vendas.DataVenda <= dataFinal).Sum(vendas => vendas.Quantidade);
        }


    }
}
