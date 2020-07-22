﻿using System;
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

        public SeriesesController(
            IRepository<Series> seriesRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Category> categoryRepository
        )
        {
            this.seriesRepository = seriesRepository;
            this.bouquetRepository = bouquetRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await PrepareViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult AddEpisode([Bind("Episodes")] Series series)
        {
            for (int i = 0; i < series.SeasonData.Length; i++)
            {
                for (int y = 0; y < series.SeasonData[i]; ++y)
                {
                    series.Episodes.Add(new Episode { 
                        Season = i + 1,
                        Number = y + 1
                    });
                }
            }
            return PartialView("~/Views/Partials/_Episode.cshtml", series);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.SERIES);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}
