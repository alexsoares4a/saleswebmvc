using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Aniversário")]
        [DataType(DataType.Date)]
        public DateTime DataAniversario { get; set; }

        [Display(Name = "Salário Base")]
        [DataType(DataType.Currency)]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public ICollection<RegistroVendas> ListaVendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(string nome, string email, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            //Id = id;
            Nome = nome;
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
