using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Streamia.Models;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly IRepository<Setting> settingRepository;

        public SettingsController (IRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> General()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> General(Setting model)
        {
            if (ModelState.IsValid)
            {
                //await settingRepository.Edit(setting);
                return RedirectToAction(nameof(General));
            }

            return RedirectToAction(nameof(General));
        }

    }
}
