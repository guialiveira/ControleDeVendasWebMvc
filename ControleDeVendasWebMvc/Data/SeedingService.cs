using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendasWebMvc.Models;
using Microsoft.EntityFrameworkCore.Internal;
using ControleDeVendasWebMvc.Models.Enums;

namespace ControleDeVendasWebMvc.Data
{
    public class SeedingService
    {
        private ControleDeVendasWebMvcContext _context;

        public SeedingService(ControleDeVendasWebMvcContext context)
        {
            _context = context;
        }

        //popula a base de dados
        public void Seed()
        {
            //se já existe dados no banco não faz nada
            if ( _context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SellesRecord.Any())// Any testa se existe registro na tabela
            {
                return; //O Db já foi populado
            }

            //duas formas de declarar
            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Moda");
            Department d4 = new Department(4, "Livros");
            Department d5 = new Department { Id = 5, Name = "Brinquedos"};

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SellesRecord r1 = new SellesRecord(1, new DateTime(2018, 09, 25), 11000.0, SeleStatus.Billed, s1);
            SellesRecord r2 = new SellesRecord(2, new DateTime(2018, 09, 4), 7000.0, SeleStatus.Billed, s5);
            SellesRecord r3 = new SellesRecord(3, new DateTime(2018, 09, 13), 4000.0, SeleStatus.Canceled, s4);
            SellesRecord r4 = new SellesRecord(4, new DateTime(2018, 09, 1), 8000.0, SeleStatus.Billed, s1);
            SellesRecord r5 = new SellesRecord(5, new DateTime(2018, 09, 21), 3000.0, SeleStatus.Billed, s3);
            SellesRecord r6 = new SellesRecord(6, new DateTime(2018, 09, 15), 2000.0, SeleStatus.Billed, s1);
            SellesRecord r7 = new SellesRecord(7, new DateTime(2018, 09, 28), 13000.0, SeleStatus.Billed, s2);
            SellesRecord r8 = new SellesRecord(8, new DateTime(2018, 09, 11), 4000.0, SeleStatus.Billed, s4);
            SellesRecord r9 = new SellesRecord(9, new DateTime(2018, 09, 14), 11000.0, SeleStatus.Pending, s6);
            SellesRecord r10 = new SellesRecord(10, new DateTime(2018, 09, 7), 9000.0, SeleStatus.Billed, s6);
            SellesRecord r11 = new SellesRecord(11, new DateTime(2018, 09, 13), 6000.0, SeleStatus.Billed, s2);
            SellesRecord r12 = new SellesRecord(12, new DateTime(2018, 09, 25), 7000.0, SeleStatus.Pending, s3);
            SellesRecord r13 = new SellesRecord(13, new DateTime(2018, 09, 29), 10000.0, SeleStatus.Billed, s4);
            SellesRecord r14 = new SellesRecord(14, new DateTime(2018, 09, 4), 3000.0, SeleStatus.Billed, s5);
            SellesRecord r15 = new SellesRecord(15, new DateTime(2018, 09, 12), 4000.0, SeleStatus.Billed, s1);
            SellesRecord r16 = new SellesRecord(16, new DateTime(2018, 10, 5), 2000.0, SeleStatus.Billed, s4);
            SellesRecord r17 = new SellesRecord(17, new DateTime(2018, 10, 1), 12000.0, SeleStatus.Billed, s1);
            SellesRecord r18 = new SellesRecord(18, new DateTime(2018, 10, 24), 6000.0, SeleStatus.Billed, s3);
            SellesRecord r19 = new SellesRecord(19, new DateTime(2018, 10, 22), 8000.0, SeleStatus.Billed, s5);
            SellesRecord r20 = new SellesRecord(20, new DateTime(2018, 10, 15), 8000.0, SeleStatus.Billed, s6);
            SellesRecord r21 = new SellesRecord(21, new DateTime(2018, 10, 17), 9000.0, SeleStatus.Billed, s2);
            SellesRecord r22 = new SellesRecord(22, new DateTime(2018, 10, 24), 4000.0, SeleStatus.Billed, s4);
            SellesRecord r23 = new SellesRecord(23, new DateTime(2018, 10, 19), 11000.0, SeleStatus.Canceled, s2);
            SellesRecord r24 = new SellesRecord(24, new DateTime(2018, 10, 12), 8000.0, SeleStatus.Billed, s5);
            SellesRecord r25 = new SellesRecord(25, new DateTime(2018, 10, 31), 7000.0, SeleStatus.Billed, s3);
            SellesRecord r26 = new SellesRecord(26, new DateTime(2018, 10, 6), 5000.0, SeleStatus.Billed, s4);
            SellesRecord r27 = new SellesRecord(27, new DateTime(2018, 10, 13), 9000.0, SeleStatus.Pending, s1);
            SellesRecord r28 = new SellesRecord(28, new DateTime(2018, 10, 7), 4000.0, SeleStatus.Billed, s3);
            SellesRecord r29 = new SellesRecord(29, new DateTime(2018, 10, 23), 12000.0, SeleStatus.Billed, s5);
            SellesRecord r30 = new SellesRecord(30, new DateTime(2018, 10, 12), 5000.0, SeleStatus.Billed, s2);


            _context.Department.AddRange(d1, d2, d3, d4); //AddRange permite add varios de uma vez

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SellesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges(); //Salva e confirma as alterações no Banco de dados
        }
    }
}
