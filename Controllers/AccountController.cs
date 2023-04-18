using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyCommune.Models.ViewModel.Account;
using MyCommune.Services.Account;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MyCommune.DataModels.Account;
using MyCommune.Services.Utility;
using MyCommune.Utilities;
using MyCommune.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyCommune.Controllers
{
    public class AccountController : Controller
    {
        public readonly IConfiguration _config;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        public AccountController(IConfiguration configuration, IAccountService accountService, IMapper mapper, IEmailService emailService)
        {
            _config = configuration;
            _accountService = accountService;
            _mapper = mapper;
            _emailservice = emailService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Register([FromForm] RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                Registration register = _mapper.Map<Registration>(registrationModel);
                ServiceResponse serviceResponse = _accountService.Register(register);
                if (serviceResponse.Status == StatusType.Failure)
                {
                    ModelState.AddModelError("Email", serviceResponse.ErrorMessage);
                }
                return View();
            }
            else
                return View(registrationModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            LoginModel model = new LoginModel { ReturnUrl = "" };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginModel registrationModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ServiceResponse res = await _accountService.IsRegistered(registrationModel.Email, registrationModel.Password);

                if (res.Status == StatusType.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, registrationModel.Email),
                        new Claim("FullName", registrationModel.Email),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = registrationModel.RememberMe,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, res.ErrorMessage);
                }
            }
            return View(registrationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("ReturnUrl");
            return RedirectToAction("Login", "Account");
        }


        [AllowAnonymous]
        public ViewResult ForgotPassword()
        {
            return View();
        }


        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> ForgotPassword([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ServiceResponse res = await _accountService.IsRegisteredEmail(email);
                if (res.Status == StatusType.Success)
                {
                    await _emailservice.SendEmail(EmailUtils.EmailSubjects.ForgotEmailSubject, string.Format(EmailUtils.EmailBody.ForgotEmailBody, Request.Scheme + "://" + Request.Host), email);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, res.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "");
            }
            return View();
        }

        [AllowAnonymous, HttpGet]
        public ViewResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> ResetPassword([FromForm] ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                await Task.Delay(0);
            }

            return View();
        }

    }
}
