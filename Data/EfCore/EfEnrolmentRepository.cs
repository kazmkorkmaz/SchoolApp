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

        public IQueryable<Enrollment> Enrollments => _dbContext.Enrollments;

        public void CreateEnrollment(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public void EditEnrollment(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public void EditEnrollment(Enrollment enrollment, int enrollmentId)
        {
            throw new NotImplementedException();
        }
    }
}