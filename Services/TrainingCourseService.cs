using TBADatalyticsSolutions.Data;
using TBADatalyticsSolutions.IServices;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Services;

public class TrainingCourseService : ITrainingCourseService
{
    private readonly AppDbContext _context;

    public TrainingCourseService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TrainingCourse> GetAllCourses()
    {
        return _context.TrainingCourses.ToList();
    }

    public TrainingCourse? GetCourseById(int id)
    {
        return _context.TrainingCourses.Find(id);
    }

    public void AddCourse(TrainingCourse course)
    {
        _context.TrainingCourses.Add(course);
        _context.SaveChanges();
    }

    public void UpdateCourse(TrainingCourse course)
    {
        _context.TrainingCourses.Update(course);
        _context.SaveChanges();
    }

    public void DeleteCourse(int id)
    {
        var course = _context.TrainingCourses.Find(id);
        if (course != null)
        {
            _context.TrainingCourses.Remove(course);
            _context.SaveChanges();
        }
    }
}