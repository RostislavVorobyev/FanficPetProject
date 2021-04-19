using FictionLogicLayer.ServiceInterfaces;
using FictionUILayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FictionUILayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(model.Email, model.UserName, model.Password);
                if (result.Succeeded)
                {
                    await _userService.Authenticate(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInresult = await SignIn(model);
                if (signInresult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        private Task<Microsoft.AspNetCore.Identity.SignInResult> SignIn(LoginViewModel model)
        {
            if (model.RememberMe)
            {
                return _userService.AuthenticateAndRemember(model.Login, model.Password);
            }
            return _userService.Authenticate(model.Login, model.Password);
        }
    }
}

