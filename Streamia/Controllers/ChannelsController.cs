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
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Transcode> transcodeRepository;

        public ChannelsController(
            IRepository<Channel> channelRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Server> serverRepository,
            IRepository<Category> categoryRepository,
            IRepository<Transcode> transcodeRepository
        )
        {
            this.channelRepository = channelRepository;
            this.bouquetRepository = bouquetRepository;
            this.serverRepository = serverRepository;
            this.categoryRepository = categoryRepository;
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
                if (model.SourcePath.Length == 0)
                {
                    ModelState.AddModelError("Source", "Please select a folder from one of your servers");
                    await PrepareViewBag();
                    return View(model);
                }

                foreach (var bouquetId in model.BouquetIds)
                {
                    model.BouquetChannels.Add(new BouquetChannel
                    {
                        ChannelId = model.Id,
                        BouquetId = bouquetId
                    });
                }

                model.State = StreamState.Transcoding;

                await channelRepository.Add(model);
                return RedirectToAction(nameof(Manage));
            }

            await PrepareViewBag();
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
            return View(await channelRepository.GetAll());
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.Online);
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.Channels);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            ViewBag.TranscodeProfiles = await transcodeRepository.GetAll();
        }
    }
}
