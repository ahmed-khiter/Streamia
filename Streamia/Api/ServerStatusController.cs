using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;
using Streamia.Realtime;

namespace Streamia.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ServerStatusController : ControllerBase
    {
        private readonly IRepository<Server> serverService;
        private readonly IHubContext<ServerStatusHub> serverHub;

        public ServerStatusController(IRepository<Server> serverService, IHubContext<ServerStatusHub> serverHub)
        {
            this.serverService = serverService;
            this.serverHub = serverHub;
        }

        [Route("edit/{id}/{state}")]
        public async Task<IActionResult> Edit(int id, ServerState state)
        {
            var server = await serverService.GetById(id);
            if (server != null)
            {
                server.ServerState = state;
                await serverService.Edit(server);
                await serverHub.Clients.All.SendAsync("UpdateSignal", new { id, state });
            }
            return Ok();
        }
    }
}