﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using ControleDeVendasWebMvc.Models;
using ControleDeVendasWebMvc.Models.ViewModels;
using ControleDeVendasWebMvc.Services;
using ControleDeVendasWebMvc.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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

            if (!ModelState.IsValid)//Validação do lado do servido
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);

                return View(seller);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {Message = "Id não fornecido" });
            }

            var obj = _sellerService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id não existe" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id não fornecido" });
            }

            var obj = _sellerService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id não existe" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id não fornecido" });
            }

            var obj = _sellerService.BuscaPorId(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id não existe" });
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)//Validação do lado do servido
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Ids não correspondem" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }


        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
