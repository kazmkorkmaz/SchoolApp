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
        public IQueryable<Lecturer> Lecturers => _dbContext.Lecturers;


        public void CreateLecturer(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }

        public void EditLecturer(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }

        public void EditLecturer(Lecturer lecturer, int lecturerId)
        {
            throw new NotImplementedException();
        }
    }
}