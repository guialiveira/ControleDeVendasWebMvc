using ControleDeVendasWebMvc.Data;
using ControleDeVendasWebMvc.Models;
using ControleDeVendasWebMvc.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            _context.Add(obj);
            _context.SaveChanges();

        }

        public Seller BuscaPorId(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); //include faz um iner join com departamento
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))//Any confere se existe então estou conferindo se não existe um vendedor com esse id no db
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
