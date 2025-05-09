using Microsoft.EntityFrameworkCore;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<TrainingCourse> TrainingCourses { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; } // optional

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Services
        modelBuilder.Entity<Service>().HasData(
            new Service
            {
                Id = 1,
                Title = "Research Analysis",
                Description = "Professional research support using qualitative and quantitative data techniques.",
                IconClass = "icons/research.png"
            },
            new Service
            {
                Id = 2,
                Title = "Business Intelligence",
                Description = "Transform your business data into actionable insights and performance metrics.",
                IconClass = "icons/bi.png"
            },
            new Service
            {
                Id = 3,
                Title = "Data Analytics Consulting",
                Description = "Expert analytics advisory services for smarter decision-making.",
                IconClass = "icons/consulting.png"
            },
            new Service
            {
                Id = 4,
                Title = "Data Analytics Training",
                Description = "Hands-on training in Excel, SPSS, R, Python, and MySQL for aspiring analysts.",
                IconClass = "icons/training.png"
            }
        );

        // Seed TrainingCourses
        modelBuilder.Entity<TrainingCourse>().HasData(
            new TrainingCourse
            {
                Id = 1,
                CourseTitle = "Introduction to Data Analytics",
                Description = "Learn the basics of analyzing data using modern tools.",
                Instructor = "Tahir Bastu Abiodun",
                StartDate = new DateTime(2025, 6, 1),
                DurationWeeks = 4,
                Level = "Beginner",
                Price = 150.00M
            },
            new TrainingCourse
            {
                Id = 2,
                CourseTitle = "Power BI for Business Intelligence",
                Description = "Develop interactive dashboards and visual reports with Power BI.",
                Instructor = "Adeola Martins",
                StartDate = new DateTime(2025, 6, 10),
                DurationWeeks = 5,
                Level = "Intermediate",
                Price = 250.00M
            },
            new TrainingCourse
            {
                Id = 3,
                CourseTitle = "Python for Data Science",
                Description = "Harness the power of Python for data analysis and machine learning.",
                Instructor = "Bolu Adeyemi",
                StartDate = new DateTime(2025, 7, 1),
                DurationWeeks = 6,
                Level = "Intermediate",
                Price = 300.00M
            },
            new TrainingCourse
            {
                Id = 4,
                CourseTitle = "Advanced Machine Learning with Scikit-Learn",
                Description = "Train and evaluate machine learning models with real-world datasets.",
                Instructor = "Kemi Yusuf",
                StartDate = new DateTime(2025, 8, 5),
                DurationWeeks = 8,
                Level = "Advanced",
                Price = 400.00M
            }
        );
    }
}