using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Repositories;
using Streamia.Services;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StreamController : Controller
    {
        private readonly ILogger<StreamController> _logger;
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Server> Servers { get; set; }
        public IEnumerable<Bouquet> Bouquets { get; set; }

        private readonly IGenericRepository<Stream> _streamService;
        private readonly IGenericRepository<Bouquet> _bouquetService;
        private readonly ICategoryRepository<Category> _categoryService;
        private readonly IServerRepository<Server> _serverService;


        public StreamController(ILogger<StreamController> logger,
                IGenericRepository<Stream> StreamService,
                IGenericRepository<Bouquet> BouquetService,
                 ICategoryRepository<Category> CategoryService,
                 IServerRepository<Server> ServerService
                )
        {
            _logger = logger;
            _streamService = StreamService;
            _bouquetService = BouquetService;
            _categoryService = CategoryService;
            _serverService = ServerService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categoryService.GetByType(CategoryType.LIVE);
            ViewBag.Servers = await _serverService.GetAllActive();
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Stream model)
        {
            if (ModelState.IsValid)
            {
                await _streamService.Add(model);
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Categories = await _categoryService.GetByType(CategoryType.LIVE);
            ViewBag.Servers = await _serverService.GetAllActive();
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await _streamService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Stream = await _streamService.GetById(id);
            if (Stream == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            return View();
        }

        [HttpGet]
          public async Task<IActionResult> Edit(int id)
          {
                ViewBag.Categories = await _categoryService.GetByType(CategoryType.LIVE);
                ViewBag.Servers = await _serverService.GetAllActive();
                ViewBag.Bouquets = await _bouquetService.GetAll();
                var stream = await _streamService.GetById(id);
                if(stream == null)
                {
                    return NotFound();
                }
                return View(stream);
          }

        [HttpPost]
        public async Task<IActionResult> Edit(Stream model)
        {

            if (ModelState.IsValid)
            {
                var Stream = await _streamService.GetById(model.Id);
                if (Stream != null)
                {
                    await _streamService.Edit(model);
                    return RedirectToAction(nameof(Manage));
                }

                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetByType(CategoryType.LIVE);
            ViewBag.Servers = await _serverService.GetAllActive();
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _streamService.Delete(id);
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Delete = "Faild Delete";
            return View(nameof(Manage));
        }

    }
}