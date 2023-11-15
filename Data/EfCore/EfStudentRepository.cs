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
        public IQueryable<Student> Students => _dbContext.Students;

        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student student, int studentId)
        {
            throw new NotImplementedException();
        }
    }
}