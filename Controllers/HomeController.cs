using Microsoft.AspNetCore.Mvc;
using TBADatalyticsSolutions.Data;

namespace TBADatalyticsSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /
        public IActionResult Index()
        {
            var services = _context.Services.ToList(); // Fetch all services from DB
            return View(services);
        }

        // GET: /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
