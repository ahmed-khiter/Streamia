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
        private readonly IRepository<SeriesServer> seriesServerRepository;
        private readonly IRepository<BouquetSeries> bouquetSeriesRepository;
        private readonly IRepository<Transcode> transcodeRepository;

        public SeriesesController(
            IRepository<Series> seriesRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Category> categoryRepository,
            IRepository<Server> serverRepository,
            IRepository<SeriesServer> seriesServerRepository,
            IRepository<BouquetSeries> bouquetSeriesRepository,
            IRepository<Transcode> transcodeRepository
        )
        {
            this.seriesRepository = seriesRepository;
            this.bouquetRepository = bouquetRepository;
            this.categoryRepository = categoryRepository;
            this.serverRepository = serverRepository;
            this.seriesServerRepository = seriesServerRepository;
            this.bouquetSeriesRepository = bouquetSeriesRepository;
            this.transcodeRepository = transcodeRepository;
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

                List<uint> serverIds = new List<uint>();

                for (int i = 0; i < model.Episodes.Count; i++)
                {
                    model.Episodes[i].SeriesId = model.Id;

                    if (model.Episodes[i].Source != null)
                    {
                        var sourceComponents = model.Episodes[i].Source.Split('/');

                        if (uint.TryParse(sourceComponents[0], out uint serverId))
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

        [HttpPost]
        public async Task<IActionResult> Delete(uint id)
        {
            await seriesServerRepository.Delete(m => m.SeriesId == id);
            await bouquetSeriesRepository.Delete(m => m.SeriesId == id);
            await seriesRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var model = await seriesRepository.GetAll(new string[] { "Category" });
            return View(model);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.Serieses);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.Online);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            ViewBag.TranscodeProfiles = await transcodeRepository.GetAll();
        }
    }
}
