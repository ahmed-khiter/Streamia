using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Streamia.Helpers;
using Streamia.Models;

namespace Streamia.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TmdbApiController : Controller
    {
        
        public async Task<string> GetMoviesFromTmdbAsync(string searchType)
        {
            var apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.getMovies.Replace("{searchType}", searchType)}{ApiConstants.apiKey}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return (await client.ExecuteAsync(request)).Content;
        }

        public async Task<string> GetMovieFromTmdbById(long id)
        {
            var apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.movieById.Replace("{movieId}", id.ToString())}{ApiConstants.apiKey}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return (await client.ExecuteAsync(request)).Content;
        }
        public async Task<string> GetMovieFromTmdbByIdAsync(long id)
        {
            var apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.movieById.Replace("{movieId}", id.ToString())}{ApiConstants.apiKey}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return (await client.ExecuteAsync(request)).Content;
        }
    }
}