using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Helpers;
using Streamia.ViewModels;
using System.Net;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Streamia.Controllers
{
    public class ResellersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public ResellersController
        (
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    AddMAG = model.AddMag,
                    AddEnigma = model.AddEnigma,
                    MonitorMagOnly = model.MonitorMagOnly,
                    MonitorEnigmaOnly = model.MonitorEnigmaOnly,
                    LockSTB = model.LockSTB,
                    Restream = model.Restream
                };

                if (model.TrialAccount)
                {
                    user.TrialAccount = true;

                    if (model.TrialDays < 1)
                    {
                        ModelState.AddModelError("TrialDays", "Trial period should be at least 1 day");
                        return View(model);
                    }

                    user.TrialDays = model.TrialDays;
                }

                var createResult = await userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    var claims = new List<Claim>();

                    if (user.AddMAG)
                    {
                        claims.Add(new Claim("AddMag", "true"));
                    }

                    if (user.AddEnigma)
                    {
                        claims.Add(new Claim("AddEnigma", "true"));
                    }

                    claims.Add(new Claim("IsReseller", "true"));

                    var addClaimsResult = await userManager.AddClaimsAsync(user, claims);

                    if (addClaimsResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Manage));
                    }

                    foreach (var error in addClaimsResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var resellers = await userManager.Users.ToListAsync();
            return View(resellers);
        }
    }
}