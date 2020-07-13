using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IptvUsersController : Controller
    {
        public IEnumerable<Bouquet> Bouquets { get; set; }

        private readonly IRepository<IptvUser> iptvRepository;
        private readonly IRepository<Bouquet> bouquetRepository;

        public IptvUsersController(
            IRepository<IptvUser> iptvRepository,
            IRepository<Bouquet> bouquetRepository
        )
        {
            this.iptvRepository = iptvRepository;
            this.bouquetRepository = bouquetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IptvUser model)
        {
            if (ModelState.IsValid)
            {
                await iptvRepository.Add(model);
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await iptvRepository.Delete(id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<IptvUser> data;
            if (keyword != null)
            {
                data = await iptvRepository.Search(m => m.Username.Contains(keyword));
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await iptvRepository.GetAll(new string[] { "Bouquet" });
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            var user = await iptvRepository.GetById(id, new string[] { "Bouquet", "Bouquet.BouquetStreams", "Bouquet.BouquetStreams.Stream" });
            return File(Encoding.UTF8.GetBytes("test"), "text/m3u8", "tv-file.m3u8");
        }
    }
}