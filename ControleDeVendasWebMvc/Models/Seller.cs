﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVendasWebMvc.Models
{
    //Modelo de vendedor
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public ICollection<SellesRecord> Sales { get; set; } = new List<SellesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            this.Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Adiciona uma venda na lista do vendedor
        public void AddSales(SellesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SellesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Retrona total de vendas no pediodo
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);  //Sum faz a soma e Amount junta tudo
        }
    }
}
