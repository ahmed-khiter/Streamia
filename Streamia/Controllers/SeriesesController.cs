using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    public class SeriesesController : Controller
    {
        private readonly IRepository<Series> seriesRepository;
        private readonly IRepository<Bouquet> bouquetRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Server> serverRepository;

        public SeriesesController(
            IRepository<Series> seriesRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Category> categoryRepository,
            IRepository<Server> serverRepository
        )
        {
            this.seriesRepository = seriesRepository;
            this.bouquetRepository = bouquetRepository;
            this.categoryRepository = categoryRepository;
            this.serverRepository = serverRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await PrepareViewBag();
            return View();
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.SERIES);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.ONLINE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}
