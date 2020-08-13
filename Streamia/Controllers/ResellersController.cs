﻿using System;
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
        private readonly IWebHostEnvironment hostEnvironment;

        public UserManager<AppUser> userManager { get; }

        public SignInManager<AppUser> SignInManager { get; }

        public ResellersController
        (
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment hostEnvironment
        )
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Add()
        {

            if (SignInManager.IsSignedIn(User) && !(User.IsInRole("Admin")))
            {
                return RedirectToAction("AccessDenied");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
            if (SignInManager.IsSignedIn(User) && !(User.IsInRole("Admin")))
            {
                return RedirectToAction("AccessDenied");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    string profilePicture = Upload.UploadProfilePicture(model, hostEnvironment);
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        ProfilePicture = profilePicture,
                        Name = model.Name,
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var result2 = await userManager.AddToRoleAsync(user, "Reseller");
                        if (result2.Succeeded)
                        {
                            return RedirectToAction("index", "Home");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }                
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await userManager.GetUsersInRoleAsync("Reseller"));
        }
    }
}