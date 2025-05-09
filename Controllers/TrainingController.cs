using Microsoft.AspNetCore.Mvc;
using TBADatalyticsSolutions.Data;

namespace TBADatalyticsSolutions.Controllers;

[Route("[controller]")]
public class TrainingController : Controller
{
    private readonly AppDbContext _context;

    public TrainingController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var courses = _context.TrainingCourses.ToList();
        return View(courses);
    }
}