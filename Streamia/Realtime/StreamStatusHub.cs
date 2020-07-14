using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Helpers;
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
            var stream = await streamRepository.GetById(streamId, new string[] { "StreamServers", "StreamServers.Server", "StreamServerPids", "StreamServerPids.Server" });
            if (stream != null)
            {
                if (stream.State != streamState)
                {
                    try
                    {
                        if (streamState == StreamState.STARTED)
                        {
                            var pidsList = new List<StreamServerPid>();
                            foreach(var server in stream.StreamServers)
                            {
                                var client = new SshClient(server.Server.Ip, "root", server.Server.RootPassword);
                                var command = new FFMPEGCommandGenerator {
                                    InputSource = stream.Source,
                                    OutputSource = $"rtmp://localhost/live/{stream.StreamKey}",
                                    StreamLoop = "-1",
                                    VideoCodec = "libx264",
                                    VideoProfile = "baseline",
                                    AudioCodec = "aac",
                                    Format = "flv"
                                };
                                client.Connect();
                                var cmd = client.CreateCommand(command.Generate());
                                var result = cmd.Execute();
                                int pid = int.Parse(result);
                                client.RunCommand($"disown -h {pid}");
                                client.Disconnect();
                                client.Dispose();
                                pidsList.Add(new StreamServerPid
                                {
                                    StreamId = stream.Id,
                                    ServerId = server.Server.Id,
                                    Pid = pid
                                });
                            }
                            stream.State = StreamState.STARTED;
                            await streamServerPidRepository.Add(pidsList);
                        }
                        else if (streamState == StreamState.STOPPED)
                        {
                            foreach (var pid in stream.StreamServerPids)
                            {
                                var client = new SshClient(pid.Server.Ip, "root", pid.Server.RootPassword);
                                string command = $"kill -9 {pid.Pid}";
                                client.Connect();
                                client.RunCommand(command);
                                client.Disconnect();
                                client.Dispose();
                            }
                            await streamServerPidRepository.Delete(m => m.StreamId == stream.Id);
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
