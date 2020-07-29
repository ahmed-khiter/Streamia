using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.ViewModels;

namespace Streamia.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IWebHostEnvironment _hostingEnviroment;
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }


        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            , IWebHostEnvironment env,
            ILogger<AccountController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _hostingEnviroment = env;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction(nameof(LogIn));
                }
                var result = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                await SignInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", "Settings");
            }
            return View(model);
        }

       

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse([Bind("Email", Prefix = "Email")]string email)
        {
            var User = await UserManager.Users.FirstOrDefaultAsync(p => p.Email == email);
            if (User == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"E-mail: {email} is already in use ");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public  IActionResult Register()
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (SignInManager.IsSignedIn(User) && !(User.IsInRole("Admin")))
            {
                return RedirectToAction("AccessDenied");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,                       
                    };

                    var result = await UserManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        await SignInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "Home");
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
        [AllowAnonymous]
        public IActionResult SuccessRegister()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("services", "service");
            }
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user Id {userId} is invalid";
                return View("NotFound");
            }

            var result = await UserManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, true);
                return View();
            }
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            ViewBag.Login = "active";
            if (SignInManager.IsSignedIn(User) && !(User.IsInRole("Admin")))
            {
                return RedirectToAction("AccessDenied");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model, string returnUrl = null)
        {
            ViewBag.Login = "active";
            if (ModelState.IsValid)
            {
                var checkState = await UserManager.FindByEmailAsync(model.Email);

                if (checkState == null)
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login ");
                    return View(model);
                }                

                var result = await SignInManager
                    .PasswordSignInAsync(checkState.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("services", "Service");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Password or Email is wrong!!");
                }
            }
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null && await UserManager.IsEmailConfirmedAsync(user))
                {
                    #region send Email 
                    var token = await UserManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                                                       new { email = model.Email, token = token }, Request.Scheme);
                    _logger.Log(LogLevel.Warning, passwordResetLink);

                    if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    //string linkk = $"<a href=\"{passwordResetLink}\">Click here</a>";
                    //var messgaeContent = new Message();
                    //var message = new MimeMessage();
                    //message.From.Add(new MailboxAddress("LaunchCentre", "5iter.2013@gmail.com"));
                    //message.To.Add(new MailboxAddress(user.UserName, user.Email));
                    //message.Subject = "Reset Password";
                    //message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    //{
                    //    Text = $"Dear {user.CompanyName} ,{string.Format("<br/>", "to reset Password")}to reset password please {string.Format(linkk, messgaeContent.Payload)}",
                    //};

                    //using (var Client = new SmtpClient())
                    //{

                    //    Client.AuthenticationMechanisms.Remove("XOAUTH2");
                    //    await Client.ConnectAsync("smtp.gmail.com", 587, false);
                    //    await Client.AuthenticateAsync("5iter.2013@gmail.com", "a7med@khiter@programmer_man");
                    //    await Client.SendAsync(message);
                    //    await Client.DisconnectAsync(true);
                    //}

                    return View("ForgotPasswordConfirmation");
                    #endregion

                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await UserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }
    }
}