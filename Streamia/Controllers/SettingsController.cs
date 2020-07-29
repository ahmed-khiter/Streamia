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

        private UserManager<AppUser> userManager { get; }
        private readonly IRepository<Setting> settingRepo;

        public SettingsController(
            UserManager<AppUser> userManager
            , IRepository<Setting> settingRepo
            )
        {
            this.userManager = userManager;
            this.settingRepo = settingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> General()
        {
            var user = await userManager.GetUserAsync(User);
            var setting = settingRepo.GetById(user.Setting.Id);
            return View(setting);
        }

        [HttpPost]
        public async Task<IActionResult> General(Setting model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var setting = await settingRepo.GetById(user.Setting.Id);
                setting.Price = model.Price;
                setting.SetAccountKey = model.SetAccountKey;
                setting.UnitPoint = model.UnitPoint;
                setting.UserValue = model.UserValue;
                setting.AdminUser = user;
                setting.AdminUserId = user.Id;
                await settingRepo.Edit(setting);
                return RedirectToAction(nameof(General));
            }

            return RedirectToAction(nameof(General));
         
        }

    }
}
