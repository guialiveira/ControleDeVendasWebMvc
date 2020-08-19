using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleDeVendasWebMvc.Models
{
    //Modelo de vendedor
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} de ver entre {2} e {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)] //para n exigir hora
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name= "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]//duas casas decimais
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]

        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

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
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
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
