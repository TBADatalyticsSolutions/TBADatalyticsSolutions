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
    }
}