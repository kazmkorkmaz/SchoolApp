using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }
        Task CreateStudent(Student student);
        Task EditStudent(Student student);
        Task DeleteStudent(int id);
    }
}