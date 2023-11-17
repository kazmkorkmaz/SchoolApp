using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Data.EfCore
{
    public class EfStudentRepository : IStudentRepository
    {
        private SchoolAppDbContext _dbContext;
        public EfStudentRepository(SchoolAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Student> Students => _dbContext.Students.Where(s => s.isActive);

        public async Task CreateStudent(Student student)
        {
            _dbContext.Students.Add(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                SchoolEnrollementDate = DateTime.Now,
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var _student = await _dbContext.Students.FirstOrDefaultAsync(i => i.Id == id);

            if (_student != null)
            {
                _student.isActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditStudent(Student student)
        {
            var _student = await _dbContext.Students.FirstOrDefaultAsync(i => i.Id == student.Id);

            if (_student != null)
            {
                _student.FirstName = student.FirstName;
                _student.LastName = student.LastName;
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}