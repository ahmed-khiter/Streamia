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
        private readonly IWebHostEnvironment _hostingEnviroment;

        public UserManager<AppUser> UserManager { get; }

        public SignInManager<AppUser> SignInManager { get; }

        public ResellersController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            , IWebHostEnvironment env)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _hostingEnviroment = env;
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
                    string profilePicture = Upload.UploadProfilePicture(model, _hostingEnviroment);
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        ProfilePicture = profilePicture,
                        Name = model.Name,
                    };

                    var result = await UserManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var result2 = await UserManager.AddToRoleAsync(user, "Reseller");
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

    }
}