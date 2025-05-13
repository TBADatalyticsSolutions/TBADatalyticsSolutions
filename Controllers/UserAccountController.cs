using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TBADatalyticsSolutions.Models;
using TBADatalyticsSolutions.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using TBADatalyticsSolutions.Data;

namespace TBADatalyticsSolutions.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _context;

        public AuthController(IUserService userService, AppDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserAccount model)
        {
            if (!ModelState.IsValid || model.PasswordHash != model.ConfirmPasswordHash)
            {
                ModelState.AddModelError("", "Passwords do not match or form is invalid.");
                return View("Index", model);
            }

            if (await _userService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("", "Email is already registered.");
                return View("Index", model);
            }

            await _userService.RegisterUserAsync(model);
            await SignInUser(model.Email);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var isValidUser = await _userService.ValidateCredentialsAsync(email, password);
            if (!isValidUser)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View("Index");
            }

            await SignInUser(email);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("signin-google")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
                return RedirectToAction("Index");

            var email = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value;

            if (!string.IsNullOrEmpty(email))
            {
                var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new UserAccount
                    {
                        Email = email,
                        PasswordHash = "",
                        ConfirmPasswordHash = "",
                        IsEmailConfirmed = true
                    };

                    _context.UserAccounts.Add(user);
                    await _context.SaveChangesAsync();
                }

                await SignInUser(user.Email);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // Removed duplicate SignInUser method

        private async Task SignInUser(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}