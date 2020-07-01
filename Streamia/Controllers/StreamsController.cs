using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StreamsController : Controller
    {
        private readonly IRepository<Stream> streamRepository;

        private readonly IRepository<Bouquet> bouquetRepository;

        private readonly IRepository<Category> categoryRepository;

        private readonly IRepository<Server> serverRepository;


        public StreamsController(
            IRepository<Stream> streamRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Category> categoryRepository,
            IRepository<Server> serverRepository
        )
        {
            this.streamRepository = streamRepository;
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

        [HttpPost]
        public async Task<IActionResult> Add(Stream model)
        {
            if (ModelState.IsValid)
            {
                await streamRepository.Add(model);
                return RedirectToAction(nameof(Manage));
            }

            await PrepareViewBag();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await streamRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var stream = await streamRepository.GetById(id);

            if (stream == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await PrepareViewBag();

            var stream = await streamRepository.GetById(id);

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
                var stream = await streamRepository.GetById(model.Id);
                if (stream != null)
                {
                    await streamRepository.Edit(model);
                    return RedirectToAction(nameof(Manage));
                }

                return NotFound();
            }
            await PrepareViewBag();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await streamRepository.Delete(id);
                return RedirectToAction(nameof(Manage));
            }
            return View(nameof(Manage));
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.LIVE);
            ViewBag.Servers = await serverRepository.Search(m => m.State == State.ONLINE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}