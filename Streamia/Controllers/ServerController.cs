using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Streamia.Helpers;
using Streamia.Models;
using Streamia.Repositories;

namespace Streamia.Controllers
{
    public class ServerController : Controller
    {
        private readonly ILogger<ServerController> _logger;
        private readonly IServerRepository<Server> _service;

        public ServerController(ILogger<ServerController> logger,
            IServerRepository<Server> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Server model)
        {
            if (ModelState.IsValid)
            {
                var server = await _service.Add(model);
                ViewData["Success"] = "Server has been added successfully";
                GetPublicIp getPublicIp = new GetPublicIp();
                string panelPublicIp = await getPublicIp.GetIPV4();
                Action runCommand = () =>
                {
                    var client = new SshClient(server.Ip, "root", server.RootPassword);

                    string serverCommands = System.IO.File.ReadAllText("InstallScripts/server");
                    string nginxConfig = System.IO.File.ReadAllText("InstallScripts/nginx-config");
                    string nginxService = System.IO.File.ReadAllText("InstallScripts/nginx-service");
                    nginxConfig = nginxConfig.Replace("MAX_CLIENTS", server.MaxClients.ToString());
                    nginxConfig = nginxConfig.Replace("RTMP_PORT", server.RtmpPort.ToString());
                    serverCommands = serverCommands.Replace("NGINX_CONFIG", nginxConfig);
                    serverCommands = serverCommands.Replace("NGINX_SERVICE", nginxService);
                    serverCommands = serverCommands.Replace("NGINX_SERVICE", nginxService);
                    serverCommands = serverCommands.Replace("PUBLIC_IP", panelPublicIp);
                    serverCommands = serverCommands.Replace("SERVER_ID", server.Id.ToString());
                    try
                    {
                        client.Connect();
                        client.RunCommand(serverCommands);
                    }
                    finally
                    {
                        client.Disconnect();
                        client.Dispose();
                    }
                };
                ThreadPool.QueueUserWorkItem(x => runCommand());
                return View("Manage");
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Server = await _service.GetById(id);
            if (Server == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Server = await _service.GetById(id);
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
                await _service.Edit(model);
                ViewData["Success"] = "Server has been updated successfully";
                return View("Manage");
            }
            ViewData["Faild"] = "Server Faild";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var servers = await _service.GetAll();
            return View(servers);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid && id != 0)
            {
                await _service.Delete(id);
                return View("Manage");
            }
            ViewBag.Faild = "Faild to delete";
            return View("Manage");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}