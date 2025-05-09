using Microsoft.AspNetCore.Mvc;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Controllers;

[Route("[controller]")]
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ContactMessage contact)
    {
        if (ModelState.IsValid)
        {
            // Handle message processing (e.g., send email or save to DB)
            ViewBag.Message = "Message sent successfully!";
        }
        return View();
    }
}