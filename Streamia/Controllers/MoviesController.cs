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
using Streamia.Helpers;
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

                if (model.TranscodeId == 0)
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

                if (model.TranscodeId > 0)
                {
                    var transcodeProfile = await transcodeRepository.GetById(model.TranscodeId);
                    var server = await serverRepository.GetById(model.ServerId);
                    var host = $"{Request.Scheme}://{Request.Host}";
                    var callbackUrl = $"{host}/api/moviestatus/edit/{model.Id}/STATE";
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
            ViewBag.TranscodeProfiles = await transcodeRepository.GetAll();
        }

        private async void Transcode(Movie movie, Transcode transcodeProfile, Server server, string callbackUrl)
        {
            var client = new SshClient(server.Ip, "root", server.RootPassword);
            try
            {
                string successCallbackUrl = callbackUrl.Replace("STATE", StreamState.Ready.ToString());
                string transcoder = FFMPEGCommand.GenerateTranscodeParams(transcodeProfile);
                transcoder = transcoder.Replace("INPUT_SRC", movie.Source);
                transcoder = transcoder.Replace("LIST_TIME", "4");
                transcoder = transcoder.Replace("LIST_TYPE", "vod");
                transcoder = transcoder.Replace("OUTPUT_SRC_1080", $"/var/hls/{movie.StreamKey}/1080/1080_%03d.ts /var/hls/{movie.StreamKey}/1080/1080.m3u8");
                transcoder = transcoder.Replace("OUTPUT_SRC_720", $"/var/hls/{movie.StreamKey}/720/720_%03d.ts /var/hls/{movie.StreamKey}/720/720.m3u8");
                transcoder = transcoder.Replace("OUTPUT_SRC_480", $"/var/hls/{movie.StreamKey}/480/480_%03d.ts /var/hls/{movie.StreamKey}/480/480.m3u8");
                transcoder = transcoder.Replace("OUTPUT_SRC_360", $"/var/hls/{movie.StreamKey}/360/360_%03d.ts /var/hls/{movie.StreamKey}/360/360.m3u8");

                //client.Connect();
                //client.RunCommand($"mkdir /var/hls/{movie.StreamKey} && cd /var/hls/{movie.StreamKey} && mkdir 1080 720 480 360");
                //client.Disconnect();
            }
            catch (Exception)
            {
                string failCallbackUrl = callbackUrl.Replace("SERVER_ID", server.Id.ToString()).Replace("STATE", StreamState.TranscodeError.ToString());
                var httpClient = new HttpClient();
                await httpClient.GetAsync(failCallbackUrl);
            }

        }
    }
}