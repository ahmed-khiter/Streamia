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

        private int Start(Server server, string command)
        {
            var client = new SshClient(server.Ip, "root", server.RootPassword);
            try
            {
                client.Connect();
                var cmd = client.CreateCommand(command);
                var result = cmd.Execute();
                int pid = int.Parse(result);
                client.RunCommand($"disown -h {pid}");
                client.Disconnect();
                client.Dispose();
                return pid;
            } 
            catch
            {
                throw new Exception($"Failed to start stream on server {server.Name}@{server.Ip}");
            }
        }

        private void Stop(Server server, int pid)
        {
            var client = new SshClient(server.Ip, "root", server.RootPassword);
            try
            {
                client.Connect();
                client.RunCommand($"kill -9 {pid}");
                client.Disconnect();
                client.Dispose();
            } 
            catch
            {
                throw new Exception($"Failed to stop stream on server {server.Name}@{server.Ip}");
            }
        }

        public async Task UpdateState(int streamId, StreamState streamState)
        {
            var stream = await streamRepository.GetById(streamId, new string[] { "StreamServers", "StreamServers.Server", "StreamServerPids", "StreamServerPids.Server" });

            if (stream == null)
            {
                return;
            }

            if (stream.State != streamState)
            {
                return;
            }

            switch (streamState)
            {
                case StreamState.STARTED:
                    var pidsList = new List<StreamServerPid>();
                    var command = new FFMPEGCommandGenerator
                    {
                        InputSource = stream.Source,
                        OutputSource = $"rtmp://localhost/live/{stream.StreamKey}",
                        StreamLoop = "-1",
                        VideoCodec = "libx264",
                        VideoProfile = "baseline",
                        AudioCodec = "aac",
                        Format = "flv"
                    };
                    foreach (var server in stream.StreamServers)
                    {
                        int pid = Start(server.Server, command.Generate());
                        if (pid > 0)
                        {
                            pidsList.Add(new StreamServerPid
                            {
                                StreamId = stream.Id,
                                ServerId = server.Server.Id,
                                Pid = pid
                            });
                        }
                    }
                    await streamServerPidRepository.Add(pidsList);
                break;
                case StreamState.STOPPED:
                    foreach (var pid in stream.StreamServerPids)
                    {
                        Stop(pid.Server, pid.Pid);
                    }
                    await streamServerPidRepository.Delete(m => m.StreamId == stream.Id);
                break;
            }

            stream.State = streamState;
            await streamRepository.Edit(stream);
            await Clients.All.SendAsync("UpdateStreamState", new { streamId, streamState = (int) streamState });
        }
    }
}
