using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using Streamia.Helpers;
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

                model.State = StreamState.Live;
                model.Source = $"/var/hls/{model.StreamKey}/source_list.txt";

                await channelRepository.Add(model);

                var transcodeProfile = await transcodeRepository.GetById((int)model.TranscodeId);
                var servers = await serverRepository.Search(m => m.Id == model.ServerId && m.ServerState == ServerState.Online);
                var host = $"{Request.Scheme}://{Request.Host}";
                var callbackUrl = $"{host}/api/channelstatus/edit/{model.Id}/STATE";
                ThreadPool.QueueUserWorkItem(queue => Transcode(model, transcodeProfile, servers, callbackUrl));

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

        private async void Transcode(Channel channel, Transcode transcodeProfile, IEnumerable<Server> servers, string callbackUrl)
        {
            foreach (var server in servers)
            {
                var client = new SshClient(server.Ip, "root", server.RootPassword);
                try
                {
                    string successCallbackUrl = callbackUrl.Replace("STATE", StreamState.Ready.ToString());

                    var options = new Dictionary<string, string>
                    {
                        { "-f", "concat" },
                        { "-safe", "0" },
                        { "hls_time", "4" },
                        { "hls_playlist_type", "event" },
                        { "hls_flags", "delete_segments" }
                    };

                    string transcoder = FFMPEGCommand.MakeCommand(transcodeProfile, channel.Source, $"/var/hls/{channel.StreamKey}", options);
                    string prepareCommand = $"mkdir /var/hls/{channel.StreamKey}";
                    prepareCommand += $" && cd /var/hls/{channel.StreamKey}";
                    prepareCommand += " && mkdir 1080p 720p 480p 360p";

                    StringBuilder sourcePathString = new StringBuilder();

                    foreach (string path in channel.SourcePath)
                    {
                        sourcePathString.Append($"file {path}\n");
                    }

                    prepareCommand += $" && printf \"{sourcePathString}\" > source_list.txt";

                    client.Connect();
                    client.RunCommand(prepareCommand);
                    var cmd = client.CreateCommand($"nohup {transcoder} >/dev/null 2>&1 & echo $!");
                    var result = cmd.Execute();
                    int pid = int.Parse(result);
                    client.RunCommand($"disown -h {pid}");
                    client.Disconnect();
                    client.Dispose();
                }
                catch (Exception)
                {
                    string failCallbackUrl = callbackUrl.Replace("STATE", StreamState.Error.ToString());
                    var httpClient = new HttpClient();
                    await httpClient.GetAsync(failCallbackUrl);
                }
            }

        }
    }
}
