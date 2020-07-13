using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streamia.Models;
using Streamia.Models.Enums;
using Streamia.Models.Interfaces;

namespace Streamia.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<IptvUser> iptvUserRepository;
        private readonly IRepository<Stream> streamRepository;

        public AuthController(
            IRepository<IptvUser> iptvUserRepository,
            IRepository<Stream> streamRepository
        )
        {
            this.iptvUserRepository = iptvUserRepository;
            this.streamRepository = streamRepository;
        }

        [Route("authenticate/{username}/{password}/{categoryType}/{sourceId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(string username, string password, CategoryType categoryType, int sourceId)
        {
            if (!await iptvUserRepository.Exists(m => m.Username.Equals(username) && m.Password.Equals(password)))
            {
                return NotFound();
            }
            string url = null;
            switch (categoryType)
            {
                case CategoryType.LIVE:
                    var stream = await streamRepository.GetById(sourceId, new string[] { "StreamServers", "StreamServers.Server" });
                    foreach (var server in stream.StreamServers)
                    {
                        url = $"http://{server.Server.Ip}/hls/{stream.StreamKey}.m3u8";
                        break;
                    }
                    break;
            }
            return Redirect(url);
        }
    }
}
