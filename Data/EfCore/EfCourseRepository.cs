using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Course> Courses => _dbContext.Courses.Where(s => s.isActive);

        public async Task CreateCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var _course = await _dbContext.Courses.FirstOrDefaultAsync(i => i.Id == id);

            if (_course != null)
            {
                _course.isActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditCourse(Course course)
        {
            var _course = await _dbContext.Courses.FirstOrDefaultAsync(i => i.Id == course.Id);

            if (_course != null)
            {
                _course.Name = course.Name;
                _course.Credit = course.Credit;
                _course.Code = course.Code;
                _course.LecturerId = course.LecturerId;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}