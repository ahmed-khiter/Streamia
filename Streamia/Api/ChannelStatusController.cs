using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;
using Streamia.Realtime;

namespace Streamia.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ChannelStatusController : ControllerBase
    {
        private readonly IRepository<Channel> channelRepository;
        private readonly IHubContext<ChannelStatusHub> hub;

        public ChannelStatusController(IRepository<Channel> channelRepository, IHubContext<ChannelStatusHub> hub)
        {
            this.channelRepository = channelRepository;
            this.hub = hub;
        }

        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var channel = await channelRepository.GetById(id);

            if (channel != null)
            {
                if (channel.SourceCount == channel.SourceTranscodedCount)
                {
                    channel.State = StreamState.Live;
                    await hub.Clients.All.SendAsync("UpdateSignal", new { id, state = (int) StreamState.Live });
                } 
                else
                {
                    channel.SourceTranscodedCount++;
                }

                await channelRepository.Edit(channel);
            }

            return Ok();
        }

        [Route("edit/{id}/{state}")]
        public async Task<IActionResult> Edit(int id, StreamState state)
        {
            var channel = await channelRepository.GetById(id);

            if (channel != null)
            {
                channel.State = state;
                await channelRepository.Edit(channel);
                await hub.Clients.All.SendAsync("UpdateSignal", new { id, state = (int) state });
            }

            return Ok();
        }
    }
}
