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
        private readonly IBouquet<Bouquet> _service;

        public BouquetController(IBouquet<Bouquet> service)
        {
            _service = service;
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
                await _service.Add(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View();
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Bouquet bouquet = await _service.GetById(id.Value);
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
                await _service.Edit(model);
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
                await _service.Delete(id);
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
                data = await _service.Search(keyword);
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await _service.GetAll();
            }
            return View(data);
        }
    }
}