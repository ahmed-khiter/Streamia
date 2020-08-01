using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
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
            return View(new Movie());
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

                if (model.StreamDirectly)
                {
                    model.State = StreamState.Ready;
                } 
                else
                {
                    model.MovieServers.Add(new MovieServer
                    {
                        MovieId = model.Id,
                        ServerId = model.ServerId
                    });
                }
                
                await movieRepository.Add(model);

                if (!model.StreamDirectly)
                {
                    var transcodeProfile = await transcodeRepository.GetById((int) model.TranscodeId);
                    var server = await serverRepository.GetById(model.ServerId);
                    var host = $"{Request.Scheme}://{Request.Host}";
                    var callbackUrl = $"{host}/api/moviestatus/edit/SERVER_ID/{StreamState.Ready}";
                    ThreadPool.QueueUserWorkItem(queue => Transcode(model, transcodeProfile, server, callbackUrl));
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
            ViewBag.Categories = await categoryRepository.Search(m => m.CategoryType == CategoryType.Movies);
            ViewBag.Servers = await serverRepository.Search(m => m.ServerState == ServerState.Online);
            ViewBag.Bouquets = await bouquetRepository.GetAll();
        }

        private async void Transcode(Movie movie, Transcode transcodeProfile, Server server, string callbackUrl)
        {
           
            var client = new SshClient(server.Ip, "root", server.RootPassword);
            try
            {
                client.Connect();
                client.RunCommand(
                    $"ffmpeg -y -nostdin -hide_banner -err_detect careful user_agent " +
                    $"\"{movie.PosterUrl}\" -nofix_dts start_at_zero -copyts -vsync 0 -correct_ts_overflow 0" +
                    $" -avoid_negative_ts disabled -max_interleave_delta 0 -re -probesize {movie.ProbSize}  " +
                    $"-analyzeduration {movie.Duration} -safe 0  -f concat -i {movie.Source}" +
                    $" -vcodec {transcodeProfile.VideoCodec}" +
                    $" -acodic {transcodeProfile.AudioCodec} -map 0 ");
                client.Disconnect();
            }
            catch (Exception)
            {

                var httpClient = new HttpClient();
                await httpClient.GetAsync(callbackUrl);
            }
           

        }
    }
}