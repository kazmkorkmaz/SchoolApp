namespace SchoolApp.Entity
{
    public class Lecturer : User
    {

        public virtual ICollection<Course> Courses { get; } = new List<Course>();
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}