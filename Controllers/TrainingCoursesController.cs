using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBADatalyticsSolutions.Data;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Controllers;

public class TrainingCoursesController : Controller
{
    private readonly AppDbContext _context;

    public TrainingCoursesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _context.TrainingCourses.ToListAsync();
        return View(courses);
    }

    public async Task<IActionResult> Details(int id)
    {
        var course = await _context.TrainingCourses.FindAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TrainingCourse course)
    {
        if (ModelState.IsValid)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var course = await _context.TrainingCourses.FindAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TrainingCourse course)
    {
        if (id != course.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.TrainingCourses.FindAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await _context.TrainingCourses.FindAsync(id);
        if (course != null)
        {
            _context.TrainingCourses.Remove(course);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}