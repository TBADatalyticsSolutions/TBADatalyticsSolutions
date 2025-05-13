using TBADatalyticsSolutions.Models;
namespace TBADatalyticsSolutions.IServices;

public interface ITrainingCourseService
{
    IEnumerable<TrainingCourse> GetAllCourses();
    TrainingCourse? GetCourseById(int id);
    void AddCourse(TrainingCourse course);
    void UpdateCourse(TrainingCourse course);
    void DeleteCourse(int id);
}