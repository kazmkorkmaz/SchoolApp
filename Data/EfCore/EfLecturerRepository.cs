using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Data.EfCore
{
    public class EfLecturerRepository : ILecturerRepository
    {
        private SchoolAppDbContext _dbContext;

        public EfLecturerRepository(SchoolAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Lecturer> Lecturers => _dbContext.Lecturers.Where(s => s.isActive);

        public async Task CreateLecturer(Lecturer lecturer)
        {
            _dbContext.Lecturers.Add(lecturer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLecturer(int id)
        {
            var _lecturer = await _dbContext.Lecturers.FirstOrDefaultAsync(i => i.Id == id);

            if (_lecturer != null)
            {
                _lecturer.isActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditLecturer(Lecturer lecturer)
        {
            var _lecturer = await _dbContext.Lecturers.FirstOrDefaultAsync(i => i.Id == lecturer.Id);

            if (_lecturer != null)
            {
                _lecturer.FirstName = lecturer.FirstName;
                _lecturer.LastName = lecturer.LastName;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}