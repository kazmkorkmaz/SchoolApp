using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Entity
{
    public class Student : User
    {

        [Display(Name = "School Enrollment Date")]
        [Required]
        public DateTime SchoolEnrollementDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}