using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public int? Credit { get; set; }
        public int? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
        public bool isActive { get; set; } = true;
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

        public override string ToString()
        {
            return $"{Code}-{Name}";
        }

    }
}