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
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository<Category> _service;
        public CategoryController(ILogger<CategoryController> logger,
                                     ICategoryRepository<Category> service)
        {
            _logger = logger;
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
                ViewData["Success"] = "Category has been added successfully";
                return View();
            }
            ViewData["Faild"] = "Category Faild";
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
                ViewData["Success"] = "Category has been updated successfully";
                return View("Manager");
            }
            ViewData["Faild"] = "Category Faild To edit";
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