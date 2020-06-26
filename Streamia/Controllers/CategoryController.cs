using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Streamia.Database;
using Streamia.Models;
using Streamia.Repositories;

namespace Streamia.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository<Category> _service;
        private readonly StreamiaContext _context;

        public CategoryController(ICategoryRepository<Category> service, StreamiaContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category model)
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
            var category = await _service.GetById(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                await _service.Edit(model);
                ViewData["Success"] = "Operation is successfully completed";
                return View(model);
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _service.Delete(id);
            }
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<Category> data;
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