using System.ComponentModel.DataAnnotations;

namespace TBADatalyticsSolutions.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = default!;

        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        public string Subject { get; set; } = default!;

        [Required]
        public string Message { get; set; } = default!;

        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}