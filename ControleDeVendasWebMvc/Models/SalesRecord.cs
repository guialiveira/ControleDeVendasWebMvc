using ControleDeVendasWebMvc.Models.Enums;
using System;

namespace ControleDeVendasWebMvc.Models
{
    //Modelo de Registro de vendas
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SeleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(int id, DateTime date, double amount, SeleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
