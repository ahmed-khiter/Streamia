using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Helpers;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;
using Streamia.Realtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class StreamStatusHub : Hub, IState<StreamServer>
    {
        private readonly IRepository<Stream> streamRepository;

        public StreamStatusHub(IRepository<Stream> streamRepository)
        {
            this.streamRepository = streamRepository;
        }

        public async Task Update(uint sourceId, StreamState state)
        {
            var stream = await streamRepository.GetById(sourceId, new string[] { "StreamServers", "StreamServers.Server" });

            if (stream == null)
            {
                return;
            }

            if (stream.State == state)
            {
                return;
            }

            if (state == StreamState.Live)
            {
                //var command = new FFMPEGCommandGenerator
                //{
                //    InputSource = stream.Source,
                //    OutputSource = $"rtmp://localhost/live/{stream.StreamKey}",
                //    StreamLoop = "-1",
                //    VideoCodec = "libx264",
                //    VideoProfile = "baseline",
                //    AudioCodec = "aac",
                //    Format = "flv"
                //};
                //stream.StreamServers = (List<StreamServer>) Start((IList<StreamServer>) stream.StreamServers, command.Generate());
            } 
            else if (state == StreamState.Stopped)
            {
                stream.StreamServers = (List<StreamServer>) Stop((IList<StreamServer>) stream.StreamServers);
            }

            stream.State = state;
            await streamRepository.Edit(stream);
            await Clients.All.SendAsync("Update", new { sourceId, state = (int) state });
        }

        public IList<StreamServer> Start(IList<StreamServer> servers, string command)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                try
                {
                    var client = new SshClient(servers[i].Server.Ip, "root", servers[i].Server.RootPassword);
                    client.Connect();
                    var cmd = client.CreateCommand(command);
                    var result = cmd.Execute();
                    uint pid = uint.Parse(result);
                    client.RunCommand($"disown -h {pid}");
                    client.Disconnect();
                    client.Dispose();
                    servers[i].Pid = pid;
                }
                catch
                {
                    throw new Exception($"Failed to start on server {servers[i].Server.Name}@{servers[i].Server.Ip}");
                }
            }
            return servers;
        }

        public IList<StreamServer> Stop(IList<StreamServer> servers)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                try
                {
                    var client = new SshClient(servers[i].Server.Ip, "root", servers[i].Server.RootPassword);
                    client.Connect();
                    client.RunCommand($"kill -9 {servers[i].Pid}");
                    client.Disconnect();
                    client.Dispose();
                    servers[i].Pid = 0;
                }
                catch
                {
                    throw new Exception($"Failed to stop on server {servers[i].Server.Name}@{servers[i].Server.Ip}");
                }
            }
            return servers;
        }
        
    }
}
