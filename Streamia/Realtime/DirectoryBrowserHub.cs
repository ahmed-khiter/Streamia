using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class DirectoryBrowserHub : Hub
    {
        public async Task ListServerDirectory(string ip, string password, string path)
        {
            string directoryList;
            var client = new SshClient(ip, "root", password);
            try
            {
                client.Connect();
                var command = client.CreateCommand($"ls {path}");
                command.Execute();
                directoryList = command.Result;
                client.Dispose();
            }
            catch
            {
                throw new Exception($"Failed to connect to ${ip}");
            }
            await Clients.All.SendAsync("DirectoryList", new { directoryList });
        }
    }
}
