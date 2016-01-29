using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FamilyTree.ViewModels;
using FamilyTree.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyTree.Controllers
{
    [Authorize]
    [Route("Konto")]
    public class AccountController : Controller
    {
            UserManager<User> _userManager;
            SignInManager<User> _signInManager;
            ftContext _identityContext;

            public AccountController(UserManager<User> userManager,
                SignInManager<User> signInManager,
                ftContext identityContext)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _identityContext = identityContext;

            }

            public IActionResult Index()
        {
            return View();
        }
        [Route("Skapa")]
        [AllowAnonymous]
        public IActionResult Registration()
        {

            //throw new Exception();
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel viewModel, string returnUrl)
        {

            if (!ModelState.IsValid)
                return View(viewModel);

            await _identityContext.Database.EnsureCreatedAsync();

            var user = new User { UserName = viewModel.UserName};
            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.Password), result.Errors.First().Description);
                return View(viewModel);
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("index");
            else
                return Redirect(returnUrl);
        }
        //[Route("Inne")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {

            await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password,
                false, false);

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("index");
            else
                return Redirect(returnUrl);
        }
    }
}
