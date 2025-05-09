namespace TBADatalyticsSolutions.Models;

public class Testimonial
{
    public int Id { get; set; }
    public string ClientName { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Company { get; set; } = default!;
    public string Role { get; set; } = default!;
}