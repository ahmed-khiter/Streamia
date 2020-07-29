using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private readonly IRepository<Server> serverRepository;
        private readonly IRepository<MovieServer> movieServerRepository;
        private readonly IRepository<BouquetMovie> bouquetMovieRepository;
        private readonly IRepository<Transcode> transcodeRepository;

        public MoviesController(
            IRepository<Movie> movieRepository, 
            IRepository<Category> categoryRepository,
            IRepository<Bouquet> bouquetRepository,
            IRepository<Server> serverRepository,
            IRepository<MovieServer> movieServerRepository,
            IRepository<BouquetMovie> bouquetMovieRepository,
            IRepository<Transcode> transcodeRepository
        )
        {
            this.movieRepository = movieRepository;
            this.categoryRepository = categoryRepository;
            this.bouquetRepository = bouquetRepository;
            this.serverRepository = serverRepository;
            this.movieServerRepository = movieServerRepository;
            this.bouquetMovieRepository = bouquetMovieRepository;
            this.transcodeRepository = transcodeRepository;
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
                foreach (var bouquetId in model.BouquetIds)
                {
                    model.BouquetMovies.Add(new BouquetMovie
                    {
                        BouquetId = bouquetId,
                        MovieId = model.Id
                    });
                }

                if (model.ServerId > 0)
                {
                    model.MovieServers.Add(new MovieServer
                    {
                        MovieId = model.Id,
                        ServerId = model.ServerId
                    });
                }

                if (model.StreamDirectly)
                {
                    model.State = StreamState.READY;
                } 
                
                await movieRepository.Add(model);

                if (!model.StreamDirectly)
                {
                    var transcodeProfile = await transcodeRepository.GetById(model.TranscodeId);
                    var server = await serverRepository.GetById(model.ServerId);
                    var host = $"{Request.Scheme}://{Request.Host}";
                    var callbackUrl = $"{host}/api/moviestatus/edit/SERVER_ID/{StreamState.READY}";
                    ThreadPool.QueueUserWorkItem(queue => Transcode(model.Id, transcodeProfile, server, callbackUrl));
                }

                return RedirectToAction(nameof(Manage));
            }
            await PrepareViewBag();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await movieServerRepository.Delete(m => m.MovieId == id);
            await bouquetMovieRepository.Delete(m => m.MovieId == id);
            await movieRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var model = await movieRepository.GetAll(new string[] { "Category" });
            return View(model);
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.MOVIE);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.ONLINE);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }

        private async void Transcode(int movieId, Transcode transcodeProfile, Server server, string callbackUrl)
        {
            // joke will be placed here :'D
        }
    }
}