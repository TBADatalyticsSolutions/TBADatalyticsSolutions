using System.ComponentModel.DataAnnotations;

namespace TBADatalyticsSolutions.Models;

public class UserAccount
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = default!;

    [Display(Name = "Profile Picture URL")]
    public string? ProfilePictureUrl { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string PasswordHash { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPasswordHash { get; set; } = default!;

    public bool IsEmailConfirmed { get; set; } = false;

    public string ConfirmationToken { get; set; } = Guid.NewGuid().ToString();

    [Display(Name = "Date Registered")]
    public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

    [Display(Name = "User Role")]
    public string Role { get; set; } = "User"; // Default role
}