using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.Enums
{
    public enum SituacaoVendas : int
    {
        Pendente = 0,
        Faturado = 1,
        Cancelado = 2
    }
}
