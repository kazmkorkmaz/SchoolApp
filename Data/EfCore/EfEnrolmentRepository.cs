using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Data.EfCore
{
    public class EfEnrollmentRepository : IEnrollmentRepository
    {
        private SchoolAppDbContext _dbContext;

        public EfEnrollmentRepository(SchoolAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Enrollment> Enrollments => _dbContext.Enrollments.Where(s => s.isActive);

        public async Task CreateEnrollment(Enrollment enrollment)
        {
            _dbContext.Enrollments.Add(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEnrollment(int id)
        {
            var _enrollment = await _dbContext.Enrollments.FirstOrDefaultAsync(i => i.Id == id);

            if (_enrollment != null)
            {
                _enrollment.isActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditEnrollment(Enrollment enrollment)
        {
            var _enrollment = await _dbContext.Enrollments.FirstOrDefaultAsync(i => i.Id == enrollment.Id);

            if (_enrollment != null)
            {
                _enrollment.StudentId = enrollment.StudentId;
                _enrollment.CourseId = enrollment.CourseId;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}