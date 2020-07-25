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
            Series model = new Series();
            await PrepareViewBag();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Series model)
        {
            if (ModelState.IsValid)
            {
                foreach (var bouquetId in model.BouquetIds)
                {
                    model.BouquetSeries.Add(new BouquetSeries
                    {
                        BouquetId = bouquetId,
                        SeriesId = model.Id
                    });
                }

                List<int> serverIds = new List<int>();

                for (int i = 0; i < model.Episodes.Count; i++)
                {
                    model.Episodes[i].SeriesId = model.Id;

                    if (model.Episodes[i].Source != null)
                    {
                        var sourceComponents = model.Episodes[i].Source.Split('/');

                        if (int.TryParse(sourceComponents[0], out int serverId))
                        {
                            if (!serverIds.Contains(serverId))
                            {
                                model.SeriesServers.Add(new SeriesServer
                                {
                                    SeriesId = model.Id,
                                    ServerId = serverId
                                });
                            }
                            sourceComponents[0] = string.Empty;
                            model.Episodes[i].Source = string.Join('/', sourceComponents);
                            serverIds.Add(serverId);
                        }
                    }

                }

                await seriesRepository.Add(model);
                return RedirectToAction(nameof(Manage));
            }
            await PrepareViewBag();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var model = await seriesRepository.GetAll(new string[] { "Category" });
            return View(model);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.SERIES);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.ONLINE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}
