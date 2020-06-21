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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository<Category> _service;

        public CategoryController(ICategoryRepository<Category> service)
        {
            _service = service;
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _service.Delete(id);
                return View("Index");
            }
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
                return View("Manager");
            }
            ViewData["Faild"] = "Failed to complete the operation";
            return View("Manager");
        }

        public async Task<IActionResult> Manage()
        {
            return View(await _service.GetAll());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}