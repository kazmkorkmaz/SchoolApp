using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        void CreateCourse(Course course);
        void EditCourse(Course course);
        void EditCourse(Course course, int courseId);
    }
}