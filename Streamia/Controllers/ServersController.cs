using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;
using Streamia.Realtime;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServersController : Controller
    {
        private readonly IRepository<Server> serverRepository;

        public ServersController(IRepository<Server> serverRepository)
        {
            this.serverRepository = serverRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Server());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Server model)
        {
            if (ModelState.IsValid)
            {
                var server = await serverRepository.Add(model);
                var hostUrl = $"{Request.Scheme}://{Request.Host}/api/serverstatus/edit/{server.Id}/{ServerState.OFFLINE}";

                Action runCommand = async () =>
                {
                    var client = new SshClient(server.Ip, "root", server.RootPassword);

                    string serverCommands = System.IO.File.ReadAllText("InstallScripts/server");
                    string nginxConfig = System.IO.File.ReadAllText("InstallScripts/nginx-config");
                    string nginxService = System.IO.File.ReadAllText("InstallScripts/nginx-service");
                    nginxConfig = nginxConfig.Replace("MAX_CLIENTS", server.MaxClients.ToString());
                    nginxConfig = nginxConfig.Replace("RTMP_PORT", server.RtmpPort.ToString());
                    serverCommands = serverCommands.Replace("NGINX_CONFIG", nginxConfig);
                    serverCommands = serverCommands.Replace("NGINX_SERVICE", nginxService);
                    serverCommands = serverCommands.Replace("DOMAIN", null);
                    serverCommands = serverCommands.Replace("SERVER_ID", server.Id.ToString());
                    try
                    {
                        client.Connect();
                        client.RunCommand(serverCommands);
                        client.Disconnect();
                        client.Dispose();
                    } 
                    catch
                    {
                        var httpClient = new HttpClient();
                        await httpClient.GetAsync(hostUrl);
                    }
                };

                ThreadPool.QueueUserWorkItem(queue => runCommand());

                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Server = await serverRepository.GetById(id);
            if(Server == null)
            {
                return NotFound();
            }
            return View(Server);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Server model)
        {
            if (ModelState.IsValid)
            {
                await serverRepository.Edit(model);
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await serverRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await serverRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<Server> data;
            if (keyword != null)
            {
                data = await serverRepository.Search(m => m.Name.Contains(keyword) || m.Ip.Contains(keyword));
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await serverRepository.GetAll();
            }
            return View(data);
        }
    }
}