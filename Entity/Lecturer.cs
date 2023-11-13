namespace SchoolApp.Entites
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; } = new List<Course>();
    }

}