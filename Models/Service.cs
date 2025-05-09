namespace TBADatalyticsSolutions.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!; // e.g., Data Strategy, AI/ML
        public string Description { get; set; } = default!; // detailed description of the service
        public string IconClass { get; set; } = default!; // optional: for UI icon support
    }
}