
using System.Collections.Generic;
using System.Linq;
using ControleDeVendasWebMvc.Data;
using ControleDeVendasWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ControleDeVendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly ControleDeVendasWebMvcContext _context;

        public DepartmentService(ControleDeVendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
