using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class DirectoryBrowserHub : Hub
    {
        private readonly IRepository<Server> serverRepository;

        public DirectoryBrowserHub(IRepository<Server> serverRepository)
        {
            this.serverRepository = serverRepository;
        }

        public async Task ListServerDirectory(int id, string path)
        {
            Server server = await serverRepository.GetById(id);
            if (server == null)
            {
                return;
            }
            string directoryList;
            var client = new SshClient(server.Ip, "root", server.RootPassword);
            try
            {
                client.Connect();
                var command = client.CreateCommand($"cd {path} && ls | egrep -i '\\.mp4$' ; ls -d */");
                command.Execute();
                directoryList = command.Result;
                client.Dispose();
            }
            catch
            {
                throw new Exception($"Failed to connect to {server.Ip}");
            }
            await Clients.All.SendAsync("DirectoryList", new { directoryList });
        }
    }
}
