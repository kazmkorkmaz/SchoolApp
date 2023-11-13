using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Entites
{
    public class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options)
        {


        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}