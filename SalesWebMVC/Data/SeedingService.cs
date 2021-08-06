using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        //injeção de dependencia
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //método para popular o banco
        public void Seed()
        {
            //verifica se as tabelas já estão populadas
            if (_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.RegistroVendas.Any())
            {
                return;
            }

            Departamento d1 = new Departamento("Computers");
            Departamento d2 = new Departamento("Electronics");
            Departamento d3 = new Departamento("Fashion");
            Departamento d4 = new Departamento("Books");

            Vendedor s1 = new Vendedor("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor s2 = new Vendedor("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor s3 = new Vendedor("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor s4 = new Vendedor("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor s5 = new Vendedor("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor s6 = new Vendedor("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistroVendas r1 = new RegistroVendas(new DateTime(2018, 09, 25), 11000.0, SituacaoVendas.Faturado, s1);
            RegistroVendas r2 = new RegistroVendas(new DateTime(2018, 09, 4), 7000.0, SituacaoVendas.Faturado, s5);
            RegistroVendas r3 = new RegistroVendas(new DateTime(2018, 09, 13), 4000.0, SituacaoVendas.Cancelado, s4);
            RegistroVendas r4 = new RegistroVendas(new DateTime(2018, 09, 1), 8000.0, SituacaoVendas.Faturado, s1);
            RegistroVendas r5 = new RegistroVendas(new DateTime(2018, 09, 21), 3000.0, SituacaoVendas.Faturado, s3);
            RegistroVendas r6 = new RegistroVendas(new DateTime(2018, 09, 15), 2000.0, SituacaoVendas.Faturado, s1);
            RegistroVendas r7 = new RegistroVendas(new DateTime(2018, 09, 28), 13000.0, SituacaoVendas.Faturado, s2);
            RegistroVendas r8 = new RegistroVendas(new DateTime(2018, 09, 11), 4000.0, SituacaoVendas.Faturado, s4);
            RegistroVendas r9 = new RegistroVendas(new DateTime(2018, 09, 14), 11000.0, SituacaoVendas.Pendente, s6);
            RegistroVendas r10 = new RegistroVendas(new DateTime(2018, 09, 7), 9000.0, SituacaoVendas.Faturado, s6);
            RegistroVendas r11 = new RegistroVendas(new DateTime(2018, 09, 13), 6000.0, SituacaoVendas.Faturado, s2);
            RegistroVendas r12 = new RegistroVendas(new DateTime(2018, 09, 25), 7000.0, SituacaoVendas.Pendente, s3);
            RegistroVendas r13 = new RegistroVendas(new DateTime(2018, 09, 29), 10000.0, SituacaoVendas.Faturado, s4);
            RegistroVendas r14 = new RegistroVendas(new DateTime(2018, 09, 4), 3000.0, SituacaoVendas.Faturado, s5);
            RegistroVendas r15 = new RegistroVendas(new DateTime(2018, 09, 12), 4000.0, SituacaoVendas.Faturado, s1);
            RegistroVendas r16 = new RegistroVendas(new DateTime(2018, 10, 5), 2000.0, SituacaoVendas.Faturado, s4);
            RegistroVendas r17 = new RegistroVendas(new DateTime(2018, 10, 1), 12000.0, SituacaoVendas.Faturado, s1);
            RegistroVendas r18 = new RegistroVendas(new DateTime(2018, 10, 24), 6000.0, SituacaoVendas.Faturado, s3);
            RegistroVendas r19 = new RegistroVendas(new DateTime(2018, 10, 22), 8000.0, SituacaoVendas.Faturado, s5);
            RegistroVendas r20 = new RegistroVendas(new DateTime(2018, 10, 15), 8000.0, SituacaoVendas.Faturado, s6);
            RegistroVendas r21 = new RegistroVendas(new DateTime(2018, 10, 17), 9000.0, SituacaoVendas.Faturado, s2);
            RegistroVendas r22 = new RegistroVendas(new DateTime(2018, 10, 24), 4000.0, SituacaoVendas.Faturado, s4);
            RegistroVendas r23 = new RegistroVendas(new DateTime(2018, 10, 19), 11000.0, SituacaoVendas.Cancelado, s2);
            RegistroVendas r24 = new RegistroVendas(new DateTime(2018, 10, 12), 8000.0, SituacaoVendas.Faturado, s5);
            RegistroVendas r25 = new RegistroVendas(new DateTime(2018, 10, 31), 7000.0, SituacaoVendas.Faturado, s3);
            RegistroVendas r26 = new RegistroVendas(new DateTime(2018, 10, 6), 5000.0, SituacaoVendas.Faturado, s4);
            RegistroVendas r27 = new RegistroVendas(new DateTime(2018, 10, 13), 9000.0, SituacaoVendas.Pendente, s1);
            RegistroVendas r28 = new RegistroVendas(new DateTime(2018, 10, 7), 4000.0, SituacaoVendas.Faturado, s3);
            RegistroVendas r29 = new RegistroVendas(new DateTime(2018, 10, 23), 12000.0, SituacaoVendas.Faturado, s5);
            RegistroVendas r30 = new RegistroVendas(new DateTime(2018, 10, 12), 5000.0, SituacaoVendas.Faturado, s2);

            //populado a base de dados
            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(s1, s2, s3, s4, s5, s6);

            _context.RegistroVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                );

            //salvar as alterações no banco de dados
            _context.SaveChanges();

        }
    }
}
