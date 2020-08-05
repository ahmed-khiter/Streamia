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
    public class ChannelsController : Controller
    {
        private readonly IRepository<Channel> channelRepository;
        private readonly IRepository<Bouquet> bouquetRepository;
        private readonly IRepository<Server> serverRepository;
        private readonly IRepository<Transcode> transcodeRepository;

        public ChannelsController(
            IRepository<Channel> channelRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Server> serverRepository,
            IRepository<Transcode> transcodeRepository
        )
        {
            this.channelRepository = channelRepository;
            this.bouquetRepository = bouquetRepository;
            this.serverRepository = serverRepository;
            this.transcodeRepository = transcodeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await PrepareViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Channel model)
        {
            if (ModelState.IsValid)
            {
                await channelRepository.Add(model);
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await channelRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var model = 0;
            return View(model);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.Online);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            ViewBag.TranscodeProfiles = await transcodeRepository.GetAll();
        }
    }
}
