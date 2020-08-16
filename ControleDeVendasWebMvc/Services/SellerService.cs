using ControleDeVendasWebMvc.Data;
using ControleDeVendasWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVendasWebMvc.Services
{
    public class SellerService
    {
        private readonly ControleDeVendasWebMvcContext _context;

        public SellerService(ControleDeVendasWebMvcContext context)
        {
            _context = context;
        }

        //chama todos
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First(); //solução pra dar um departamento pro vendedor
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
