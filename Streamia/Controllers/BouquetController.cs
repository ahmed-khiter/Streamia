using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BouquetController : Controller
    {
        private readonly IRepository<Bouquet> bouquetRepository;

        public BouquetController(IRepository<Bouquet> bouquetRepository)
        {
            this.bouquetRepository = bouquetRepository;
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
                await bouquetRepository.Add(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View();
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Bouquet bouquet = await bouquetRepository.GetById(id.Value);
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
                await bouquetRepository.Edit(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View();
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid && id != 0)
            {
                await bouquetRepository.Delete(id);
                return RedirectToAction("Manage");
            }
            ViewBag.Faild = "Failed to complete the operation";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<Bouquet> data;
            if (keyword != null)
            {
                data = await bouquetRepository.Search(m => m.Name.Contains(keyword));
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await bouquetRepository.GetAll();
            }
            return View(data);
        }
    }
}