﻿using Microsoft.AspNetCore.SignalR;
using Streamia.Models;
using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class ServerStatusHub : Hub
    {
        public async Task SendUpdateSignal(int serverId, ServerState state)
        {
            await Clients.All.SendAsync("UpdateSignal", new { serverId, state });
        }
    }
}
