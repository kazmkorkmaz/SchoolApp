using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Entity
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "School Enrollment Date")]
        public DateTime SchoolEnrollementDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}