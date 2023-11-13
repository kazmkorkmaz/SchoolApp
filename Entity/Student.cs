namespace SchoolApp.Entites
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime SchoolEnrollementDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
    }
}