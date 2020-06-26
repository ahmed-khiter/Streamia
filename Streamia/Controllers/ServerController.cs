using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Streamia.Helpers;
using Streamia.Models;
using Streamia.Repositories;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServerController : Controller
    {
        private readonly IServer<Server> _service;

        public ServerController(IServer<Server> service)
        {
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
                ViewData["Success"] = "Operation is successfully completed";
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
                    serverCommands = serverCommands.Replace("PUBLIC_IP", null);
                    serverCommands = serverCommands.Replace("SERVER_ID", server.Id.ToString());
                    try
                    {
                        client.Connect();
                        client.RunCommand(serverCommands);
                    } 
                    catch
                    {
                        
                    }
                    finally
                    {
                        client.Disconnect();
                        client.Dispose();
                    }
                };
                ThreadPool.QueueUserWorkItem(queue => runCommand());
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
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
                ViewData["Success"] = "Operation is successfully completed";
                return View("Manage");
            }
            ViewData["Faild"] = "Operation failed to complete";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid && id != 0)
            {
                await _service.Delete(id);
                RedirectToAction(nameof(Manage));
            }
            ViewBag.Faild = "Operation failed to complete";
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<Server> data;
            if (keyword != null)
            {
                data = await _service.Search(keyword);
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await _service.GetAll();
            }
            return View(data);
        }
    }
}