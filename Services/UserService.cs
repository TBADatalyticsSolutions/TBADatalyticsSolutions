using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TBADatalyticsSolutions.Data;
using TBADatalyticsSolutions.IServices;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
        private readonly IPasswordHasher<UserAccount> _passwordHasher;

        public UserService(AppDbContext context, IPasswordHasher<UserAccount> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserAccount?> GetByEmailAsync(string email)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.UserAccounts.AnyAsync(u => u.Email == email);
        }

        public async Task RegisterUserAsync(UserAccount model)
        {
            model.PasswordHash = _passwordHasher.HashPassword(model, model.PasswordHash);
            _context.UserAccounts.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);
            if (user == null)
                return false;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
}
