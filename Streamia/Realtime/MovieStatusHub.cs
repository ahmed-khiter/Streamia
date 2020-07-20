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
    public class MovieStatusHub : Hub, IState<MovieServer>
    {
        private readonly IRepository<Movie> movieRepository;

        public MovieStatusHub(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IList<MovieServer> Start(IList<MovieServer> servers, string command)
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

        public IList<MovieServer> Stop(IList<MovieServer> servers)
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

        public async Task Update(int sourceId, StreamState state)
        {
            var movie = await movieRepository.GetById(sourceId, new string[] { "MovieServers", "MovieServers.Server" });

            if (movie == null)
            {
                return;
            }

            if (movie.State == state)
            {
                return;
            }

            if (state == StreamState.STARTED)
            {
                string command = $"nohup ffmpeg -re -stream_loop -1 -i {movie.Source} -codec copy -f flv rtmp://localhost/live/{movie.StreamKey} >/dev/null 2>&1 & echo $!";
                movie.MovieServers = (List<MovieServer>) Start((IList<MovieServer>) movie.MovieServers, command);
            }
            else if (state == StreamState.STOPPED)
            {
                movie.MovieServers = (List<MovieServer>) Stop((IList<MovieServer>) movie.MovieServers);
            }

            movie.State = state;
            await movieRepository.Edit(movie);
            await Clients.All.SendAsync("Update", new { sourceId, state = (int) state });
        }
    }
}
