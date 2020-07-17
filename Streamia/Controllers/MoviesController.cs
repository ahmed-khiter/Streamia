using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> movieRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Bouquet> bouquetRepository;

        public MoviesController(
            IRepository<Movie> movieRepository, 
            IRepository<Category> categoryRepository,
            IRepository<Bouquet> bouquetRepository
        )
        {
            this.movieRepository = movieRepository;
            this.categoryRepository = categoryRepository;
            this.bouquetRepository = bouquetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await PrepareViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie model)
        {
            if (ModelState.IsValid)
            {
                await movieRepository.Add(model);
                return View("Manage");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await movieRepository.GetAll());
        }
        public IActionResult Index()
        {
            return View();
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.MOVIE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}