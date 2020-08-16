
using System.Collections.Generic;
using System.Linq;
using ControleDeVendasWebMvc.Data;
using ControleDeVendasWebMvc.Models;

namespace ControleDeVendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly ControleDeVendasWebMvcContext _context;

        public DepartmentService(ControleDeVendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
