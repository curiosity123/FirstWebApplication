using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{


    public class AccountController : Controller
    {


        public AccountController(SignInManager<AdminUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        private SignInManager<AdminUser> signInManager;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                       credentials.Login,
                       credentials.Password,
                       true,
                       false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
           
            return View();
        }
    }
}
