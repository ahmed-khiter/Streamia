using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class StreamStatusHub : Hub
    {
        private readonly IRepository<Stream> streamRepository;
        private readonly IRepository<StreamServerPid> streamServerPidRepository;

        public StreamStatusHub(IRepository<Stream> streamRepository, IRepository<StreamServerPid> streamServerPidRepository)
        {
            this.streamRepository = streamRepository;
            this.streamServerPidRepository = streamServerPidRepository;
        }

        public async Task UpdateState(int streamId, StreamState streamState)
        {
            var stream = await streamRepository.GetById(streamId, new string[] { "StreamServers", "StreamServers.Server" });
            if (stream != null)
            {
                if (stream.State != streamState)
                {
                    try
                    {
                        if (streamState == StreamState.STARTED)
                        {
                            foreach(var server in stream.StreamServers)
                            {
                                var client = new SshClient(server.Server.Ip, "root", server.Server.RootPassword);
                                string command = $"nohup ffmpeg -stream_loop -1 -i {stream.Source} -vcodec libx264 -vprofile baseline -g 30 -acodec aac -strict -2 -f flv rtmp://localhost/live/stream >/dev/null 2>&1 & echo $!";
                                client.Connect();
                                var cmd = client.CreateCommand(command);
                                var result = cmd.Execute();
                                Console.WriteLine(int.Parse(result));
                                client.RunCommand($"disown -h {int.Parse(result)}");
                                client.Disconnect();
                                client.Dispose();
                            }
                            stream.State = StreamState.STARTED;
                        }
                        else if (streamState == StreamState.STOPPED)
                        {
                            stream.State = StreamState.STOPPED;
                        }
                        await streamRepository.Edit(stream);
                        await Clients.All.SendAsync("UpdateStreamState", new { streamId, streamState = (int) streamState });
                    } 
                    catch
                    {
                        // this is really a joke
                    }
                }
            }
        }
    }
}
