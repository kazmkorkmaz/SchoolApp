namespace SchoolApp.Entity
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? CourseId { get; set; }
        public bool isActive { get; set; } = true;
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}