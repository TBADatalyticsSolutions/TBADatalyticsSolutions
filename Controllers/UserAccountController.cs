using Microsoft.AspNetCore.Mvc;
using TBADatalyticsSolutions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TBADatalyticsSolutions.Data;

public class AuthController : Controller
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<UserAccount> _passwordHasher;

    public AuthController(AppDbContext context, IPasswordHasher<UserAccount> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
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

        if (await _context.UserAccounts.AnyAsync(u => u.Email == model.Email))
        {
            ModelState.AddModelError("", "Email is already registered.");
            return View("Index", model);
        }

        model.PasswordHash = _passwordHasher.HashPassword(model, model.PasswordHash);
        _context.UserAccounts.Add(model);
        await _context.SaveChangesAsync();

        // Create login session after registration
        await SignInUser(model.Email);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View("Index");
        }

        await SignInUser(email);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    private async Task SignInUser(string email)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
        var identity = new ClaimsIdentity(claims, "login");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(principal);
    }
}