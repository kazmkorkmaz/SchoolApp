using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface IEnrollmentRepository
    {
        IQueryable<Enrollment> Enrollments { get; }
        void CreateEnrollment(Enrollment enrollment);
        void EditEnrollment(Enrollment enrollment);
        void EditEnrollment(Enrollment enrollment, int enrollmentId);
    }
}