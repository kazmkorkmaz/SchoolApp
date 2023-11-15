using SchoolApp.Entity;

namespace SchoolApp.Data.Abstract
{
    public interface ILecturerRepository
    {
        IQueryable<Lecturer> Lecturers { get; }
        void CreateLecturer(Lecturer lecturer);
        void EditLecturer(Lecturer lecturer);
        void EditLecturer(Lecturer lecturer, int lecturerId);
    }
}