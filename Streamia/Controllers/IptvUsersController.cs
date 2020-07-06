using System;
using System.Collections.Generic;
using System.Linq;
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
                ViewBag.Success = "Operation is successfully completed";
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Faild = "Failed to complete the operation";
            ViewBag.Bouquets = await bouquetRepository.GetAll();
            return View(model);
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
    }
}