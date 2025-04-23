using App.Buss.DTO;
using App.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Threading.Tasks;

namespace App.PR.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signIn;

        public Account( UserManager<AppUser>userManager,SignInManager<AppUser> signIn )
        {
            _userManager = userManager;
            _signIn = signIn;
        }
        [HttpGet]
        public IActionResult SignUp()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is  null)
                {
                    user = await _userManager.FindByNameAsync(model.UserName);
                    if (user is  null)
                    {
                        user = new AppUser()
                        {
                            UserName = model.UserName,
                            Email = model.Email,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            IsAgree = model.IsAgree,
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);
                        //identity result function
                        if (result.Succeeded)
                        {
                            return Redirect("SignIn");
                        }

                        //case : request not success
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }
                }
            }
            ModelState.AddModelError("", "Invalid SignUp");

            return View(model);
        }

        [HttpGet]
        public  IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                      var result= await _signIn.PasswordSignInAsync(user,model.Password,model.RemmberMe,false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid SignIn");
            }
            return View(model);
        }


        public new async Task<IActionResult> SignOut()
        {
           await _signIn.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }



    }
}
