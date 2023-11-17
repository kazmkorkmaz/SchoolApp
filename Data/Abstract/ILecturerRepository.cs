using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface ILecturerRepository
    {
        IQueryable<Lecturer> Lecturers { get; }
        Task CreateLecturer(Lecturer lecturer);
        Task EditLecturer(Lecturer lecturer);
        Task DeleteLecturer(int id);
    }
}