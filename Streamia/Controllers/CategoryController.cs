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
                return StatusCode(200);
            }
            return StatusCode(500);
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> List()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var data = from tempData in _context.Categories select tempData;

                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    data = data.OrderBy(r => r.Name);
                //}

                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.Name == searchValue);
                }

                recordsTotal = data.Count();

                var output = await data.Skip(skip).Take(pageSize).ToListAsync();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data = output });

            }
            catch (Exception)
            {
                throw;
            }
            //return await _service.GetAll();
        }
    }
}