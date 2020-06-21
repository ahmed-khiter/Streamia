using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Repositories;

namespace Streamia.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BouquetController : Controller
    {
        private readonly IGenericRepository<Bouquet> _bouquetService;

        public BouquetController(IGenericRepository<Bouquet> bouquetService)
        {
            _bouquetService = bouquetService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Bouquet model)
        {
            if (ModelState.IsValid)
            {
                await _bouquetService.Add(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View();
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Bouquet bouquet = await _bouquetService.GetById(id.Value);
            if (bouquet == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            return View(bouquet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bouquet model)
        {
            if (ModelState.IsValid)
            {
                await _bouquetService.Edit(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View();
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await _bouquetService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid && id != 0)
            {
                await _bouquetService.Delete(id);
                return RedirectToAction("Manage");
            }
            ViewBag.Faild = "Failed to complete the operation";
            return View();
        }
    }
}