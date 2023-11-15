using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Data.EfCore
{
    public class EfCourseRepository : ICourseRepository
    {
        private SchoolAppDbContext _dbContext;

        public EfCourseRepository(SchoolAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Course> Courses => _dbContext.Courses;

        public void CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void EditCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void EditCourse(Course course, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}