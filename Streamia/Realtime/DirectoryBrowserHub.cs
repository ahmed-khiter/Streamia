using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
using Streamia.Models;
using Streamia.Models.Interfaces;
using Streamia.Realtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Streamia.Realtime
{
    public class DirectoryBrowserHub : Hub
    {
        private readonly IRepository<Server> serverRepository;
        private readonly IRemoteConnection remoteConnection;

        public DirectoryBrowserHub(IRepository<Server> serverRepository, IRemoteConnection remoteConnection)
        {
            this.serverRepository = serverRepository;
            this.remoteConnection = remoteConnection;
        }

        public async Task ListServerDirectory(int id, string path)
        {
            string directoryList = string.Empty;
            SshClient sshClient = null;
            Server server = null;
            if (remoteConnection.ConnectionsList[$"{id}"] == null)
            {
                server = await serverRepository.GetById(id);
                if (server == null)
                {
                    return;
                }
                sshClient = new SshClient(server.Ip, "root", server.RootPassword);
                remoteConnection.ConnectionsList.Add(id.ToString(), sshClient);
                try
                {
                    sshClient.Connect();
                    var command = sshClient.CreateCommand($"cd {path} && ls | egrep -i '\\.mp4$' ; ls -d */");
                    command.Execute();
                    directoryList = command.Result;
                }
                catch
                {
                    throw new Exception($"Failed to connect to {server.Ip}");
                }
            }
            else
            {
                try
                {
                    var command = remoteConnection.ConnectionsList[$"{id}"].CreateCommand($"cd {path} && ls | egrep -i '\\.mp4$' ; ls -d */");
                    command.Execute();
                    directoryList = command.Result;
                }
                catch
                {
                    throw new Exception($"Disconnected to the server");
                }
            }
            await Clients.All.SendAsync("DirectoryList", new { directoryList });
        }

        public void DisposeConnection(int id)
        {
            try
            {
                if (remoteConnection.ConnectionsList[id.ToString()] != null)
                {
                    remoteConnection.ConnectionsList[id.ToString()].Disconnect();
                    remoteConnection.ConnectionsList[id.ToString()].Dispose();
                    remoteConnection.ConnectionsList.Remove(id.ToString());
                }
            } 
            catch
            {
                throw new Exception("Failed to dispose current connection");
            }
        }
    }
}
