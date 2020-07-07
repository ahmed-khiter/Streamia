using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Contexts;
using Streamia.Models.Enums;
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
        private readonly IRepository<StreamServer> streamServersRepository;
        private readonly IRepository<BouquetStream> bouquetStreamsRepository;

        public StreamsController(
            IRepository<Stream> streamRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Category> categoryRepository,
            IRepository<Server> serverRepository,
            IRepository<StreamServer> streamServersRepository,
            IRepository<BouquetStream> bouquetStreamsRepository
        )
        {
            this.streamRepository = streamRepository;
            this.bouquetRepository = bouquetRepository;
            this.categoryRepository = categoryRepository;
            this.serverRepository = serverRepository;
            this.streamServersRepository = streamServersRepository;
            this.bouquetStreamsRepository = bouquetStreamsRepository;
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
                foreach (var serverId in model.ServerIds)
                {
                    model.StreamServers.Add(new StreamServer { 
                        ServerId = serverId, 
                        StreamId = model.Id
                    });
                }

                foreach (var bouquetId in model.BouquetIds)
                {
                    model.BouquetStreams.Add(new BouquetStream
                    {
                        BouquetId = bouquetId,
                        StreamId = model.Id
                    });
                }

                await streamRepository.Add(model);

                return RedirectToAction(nameof(Manage));
            }

            await PrepareViewBag();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await PrepareViewBag();

            var stream = await streamRepository.GetById(id, new string[] { "BouquetStreams", "StreamServers" });

            if(stream == null)
            {
                return NotFound();
            }

            stream.BouquetIds = new List<int>();
            stream.ServerIds = new List<int>();

            foreach(var bouquet in stream.BouquetStreams)
            {
                stream.BouquetIds.Add(bouquet.BouquetId);
            }

            foreach (var server in stream.StreamServers)
            {
                stream.ServerIds.Add(server.ServerId);
            }

            return View(stream);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Stream model)
        {

            if (ModelState.IsValid)
            {
                var stream = await streamRepository.GetById(model.Id);

                if (stream == null)
                {
                    return NotFound();
                }

                await streamServersRepository.Delete(m => m.StreamId == stream.Id);
                await bouquetStreamsRepository.Delete(m => m.StreamId == stream.Id);

                foreach (var serverId in model.ServerIds)
                {
                    stream.StreamServers.Add(new StreamServer
                    {
                        ServerId = serverId,
                        StreamId = stream.Id
                    });
                }

                foreach (var bouquetId in model.BouquetIds)
                {
                    stream.BouquetStreams.Add(new BouquetStream
                    {
                        BouquetId = bouquetId,
                        StreamId = stream.Id
                    });
                }

                await streamRepository.Edit(stream);

                return RedirectToAction(nameof(Manage));
            }
            await PrepareViewBag();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await streamRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var stream = await streamRepository.GetById(id);

            if (stream == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var result = await streamRepository.GetAll(new string[] { "Category" });
            return View(result);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.LIVE);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.ONLINE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }
    }
}