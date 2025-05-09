using System.ComponentModel.DataAnnotations;

namespace TBADatalyticsSolutions.Models;

public class UserAccount
{
    [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPasswordHash { get; set; } = default!;

        public bool IsEmailConfirmed { get; set; } = false;

        public string ConfirmationToken { get; set; } = Guid.NewGuid().ToString();

}