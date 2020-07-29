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
    public class MovieStatusHub : Hub
    {
        private readonly IRepository<Movie> movieRepository;

        public MovieStatusHub(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IList<MovieServer> Transcode(IList<MovieServer> servers, string command)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                try
                {
                    var client = new SshClient(servers[i].Server.Ip, "root", servers[i].Server.RootPassword);
                    client.Connect();
                    var cmd = client.CreateCommand(command);
                    var result = cmd.Execute();
                    int pid = int.Parse(result);
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
    }
}
