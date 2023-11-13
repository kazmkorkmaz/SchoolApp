namespace SchoolApp.Entites
{
    public class Course
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public string Name { get; set; } = null!;

        public string? Code { get; set; }

        public int? Credit { get; set; }
        public Lecturer Lecturer { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
    }
}