using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        Task CreateCourse(Course course);
        Task EditCourse(Course course);
        Task DeleteCourse(int id);
    }
}