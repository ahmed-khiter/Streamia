using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    public class SeriesStatusController : ControllerBase
    {
        private readonly IRepository<Series> seriesRepository;
        private readonly IHubContext<SeriesStatusHub> hub;

        public SeriesStatusController
        (
            IRepository<Series> seriesRepository,
            IHubContext<SeriesStatusHub> hub
        )
        {
            this.seriesRepository = seriesRepository;
            this.hub = hub;
        }

        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var series = await seriesRepository.GetById(id);

            if (series != null)
            {
                if (series.SourceTranscodedCount < series.SourceCount)
                {
                    series.SourceTranscodedCount++;
                }

                if (series.SourceCount == series.SourceTranscodedCount)
                {
                    series.State = StreamState.Ready;
                    await hub.Clients.All.SendAsync("UpdateSignal", new { id, state = (int) StreamState.Live });
                }

                await seriesRepository.Edit(series);
            }

            return Ok();
        }
    }
}
