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
    public class BouquetsController : Controller
    {
        private readonly IRepository<Bouquet> bouquetRepository;

        public BouquetsController(IRepository<Bouquet> bouquetRepository)
        {
            this.bouquetRepository = bouquetRepository;
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
                return RedirectToAction(nameof(Manage));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Bouquet bouquet = await bouquetRepository.GetById(id);
            if (bouquet == null)
            {
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
                return RedirectToAction(nameof(Manage));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await bouquetRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
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