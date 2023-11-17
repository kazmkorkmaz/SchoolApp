namespace SchoolApp.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public bool isActive { get; set; } = true;

    }
}
