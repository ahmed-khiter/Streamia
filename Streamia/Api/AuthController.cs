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
            return Redirect("https://mnmedias.api.telequebec.tv/m3u8/29880.m3u8");
        }
    }
}
