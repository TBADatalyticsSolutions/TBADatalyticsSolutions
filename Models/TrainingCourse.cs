namespace TBADatalyticsSolutions.Models
{
    public class TrainingCourse
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Instructor { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public int DurationWeeks { get; set; }
        public string Level { get; set; } = default!; // Beginner, Intermediate, Advanced
        public decimal Price { get; set; }
    }
}
