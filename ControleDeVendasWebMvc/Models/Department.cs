using System;
using System.Linq;
using System.Collections.Generic;


namespace ControleDeVendasWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //adciona vendedor no departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //Total de vendas do departamento entre as datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
