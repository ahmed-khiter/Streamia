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
    [Authorize(Roles = "Admin")]
    public class IptvUserController : Controller
    {
        private readonly ILogger<IptvUserController> _logger;
        public IEnumerable<Bouquet> Bouquets { get; set; }

        private readonly IGenericRepository<IptvUser> _iptvService;
        private readonly IGenericRepository<Bouquet> _bouquetService;
        public IptvUserController(ILogger<IptvUserController> logger,
             IGenericRepository<Bouquet> bouquetService,
              IGenericRepository<IptvUser> iptvService
                        )
        {
            _logger = logger;
            _iptvService = iptvService;
            _bouquetService = bouquetService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IptvUser model)
        {
            if (ModelState.IsValid)
            {
                await _iptvService.Add(model);

                ViewBag.Success = "Done added";
                return View("Manage");
            }
            ViewBag.Faild = "Faild";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await _iptvService.GetAll());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}