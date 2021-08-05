using SalesWebMVC.Models.Enums;
using System;

namespace SalesWebMVC.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double Quantidade { get; set; }

        public SituacaoVendas SituacaoVendas { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime dataVenda, double quantidade, SituacaoVendas situacaoVendas, Vendedor vendedor)
        {
            Id = id;
            DataVenda = dataVenda;
            Quantidade = quantidade;
            SituacaoVendas = situacaoVendas;
            Vendedor = vendedor;
        }

    }
}
