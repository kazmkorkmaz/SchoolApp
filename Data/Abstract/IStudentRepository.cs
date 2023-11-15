using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }
        void CreateStudent(Student student);
        void EditStudent(Student student);
        void EditStudent(Student student, int studentId);
    }
}