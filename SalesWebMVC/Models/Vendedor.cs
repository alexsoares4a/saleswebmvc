using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do campo {0} deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data de Aniversário")]
        [DataType(DataType.Date)]
        public DateTime DataAniversario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(100, 50000, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")]
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
