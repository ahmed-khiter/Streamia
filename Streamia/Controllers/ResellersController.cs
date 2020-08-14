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

namespace Streamia.Controllers
{
    public class ResellersController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public UserManager<AppUser> userManager { get; }

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
            return View();
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
                    GenerateMAG = model.GenerateMAG,
                    GenerateEnigma = model.GenerateEnigma,
                    MAGOnly = model.MAGOnly,
                    EnigmaOnly = model.EnigmaOnly,
                    LockSTB = model.LockSTB,
                    Restream = model.Restream
                };

                var createResult = await userManager.CreateAsync(user, model.Password);

                if (user.GenerateMAG) {
                }

                if (createResult.Succeeded)
                {
                    var addToRoleResult = await userManager.AddToRoleAsync(user, "Reseller");
                    if (addToRoleResult.Succeeded)
                    {
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }                
                }
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await userManager.GetUsersInRoleAsync("Reseller"));
        }
    }
}