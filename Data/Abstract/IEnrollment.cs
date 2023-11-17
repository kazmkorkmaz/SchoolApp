using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface IEnrollmentRepository
    {
        IQueryable<Enrollment> Enrollments { get; }
        Task CreateEnrollment(Enrollment enrollment);
        Task EditEnrollment(Enrollment enrollment);
        Task DeleteEnrollment(int id);
    }
}