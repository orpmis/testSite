using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using testASP.Models;

namespace testASP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> uManager, SignInManager<IdentityUser> sManager)
        {
            userManager = uManager;
            signInManager = sManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl) 
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser finded = await userManager.FindByNameAsync(model.UserName);
                if (finded != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult res = await signInManager.PasswordSignInAsync(finded, model.Password, true, false);
                    if (res.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
;
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
