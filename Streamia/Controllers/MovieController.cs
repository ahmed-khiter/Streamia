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
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IGenericRepository<Movie> _services;
        public MovieController(ILogger<MovieController> logger,
                   IGenericRepository<Movie> services)
        {
            _logger = logger;
            _services = services;

        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie model)
        {
            if (ModelState.IsValid)
            {
                await _services.Add(model);

                ViewBag.Success = "Done added";
                return View("Manage");
            }
            ViewBag.Faild = "Faild";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await _services.GetAll());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}