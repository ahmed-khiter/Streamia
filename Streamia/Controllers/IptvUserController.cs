using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Repositories;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IptvUserController : Controller
    {
        public IEnumerable<Bouquet> Bouquets { get; set; }

        private readonly IIptvUser<IptvUser> _iptvService;
        private readonly IBouquet<Bouquet> _bouquetService;

        public IptvUserController(
            IBouquet<Bouquet> bouquetService,
            IIptvUser<IptvUser> iptvService
        )
        {
            _iptvService = iptvService;
            _bouquetService = bouquetService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IptvUser model)
        {
            if (ModelState.IsValid)
            {
                await _iptvService.Add(model);

                ViewBag.Success = "Operation is successfully completed";
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Faild = "Failed to complete the operation";
            ViewBag.Bouquets = await _bouquetService.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string keyword)
        {
            IEnumerable<IptvUser> data;
            if (keyword != null)
            {
                data = await _iptvService.Search(keyword);
                ViewBag.Keyword = keyword;
            }
            else
            {
                data = await _iptvService.GetAll();
            }
            return View(data);
        }
    }
}