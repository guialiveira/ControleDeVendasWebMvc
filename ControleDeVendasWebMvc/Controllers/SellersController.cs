using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendasWebMvc.Models;
using ControleDeVendasWebMvc.Models.ViewModels;
using ControleDeVendasWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

//Controlador de Vendedor
namespace ControleDeVendasWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();            
            return View(list);
        }
        public IActionResult Create()
        {
            var departamento = _departmentService.FindAll();//Carregar departamentos
            var viewModel = new SellerFormViewModel { Departments = departamento };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // previne ataque 
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
