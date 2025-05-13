using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.IServices;

public interface IUserService
{
    Task<UserAccount?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task RegisterUserAsync(UserAccount model);
    Task<bool> ValidateCredentialsAsync(string email, string password);
}