using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Realtime;
using Streamia.Repositories;

namespace Streamia.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerStatusController : ControllerBase
    {
        private readonly IGenericRepository<Server> serverService;
        private readonly IHubContext<ServerStatusHub> serverHub;

        public ServerStatusController(IGenericRepository<Server> serverService, IHubContext<ServerStatusHub> serverHub)
        {
            this.serverService = serverService;
            this.serverHub = serverHub;
        }

        [Route("edit/{id}/{state}")]
        public async Task<IActionResult> Edit(int id, State state)
        {
            var server = await serverService.GetById(id);
            if (server != null)
            {
                server.State = state;
                await serverService.Edit(server);
                await serverHub.Clients.All.SendAsync("UpdateSignal", new { id, state });
            }
            return Ok();
        }

        [Route("path/{id}/{dir}")]
        public async Task<string> GetPath(int id, string dir)
        {
            var server = await serverService.GetById(id);
            var response = string.Empty;
            if (server != null)
            {
                var client = new SshClient(server.Ip, "root", server.RootPassword);
                try
                {
                    client.Connect();
                    var command = client.CreateCommand(dir);
                    command.Execute();
                    response = command.Result;
                } finally
                {
                    client.Dispose();
                }
            }
            return response;
        }
    }
}