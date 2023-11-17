using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Entity
{
    public class AddDummyData
    {
        public static void AddTestData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<SchoolAppDbContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student { Id = 1, FirstName = "Kazım", LastName = "Koyuncu", SchoolEnrollementDate = DateTime.Now, isActive = true },
                        new Student { Id = 2, FirstName = "Nazım", LastName = "Korkmaz", SchoolEnrollementDate = DateTime.Now, isActive = true }

                    );
                    context.SaveChanges();
                }
                if (!context.Lecturers.Any())
                {
                    context.Lecturers.AddRange(
                        new Lecturer { Id = 3, FirstName = "Ahmet", LastName = "Yılmaz", isActive = true },
                        new Lecturer { Id = 4, FirstName = "Ayşe", LastName = "Koç", isActive = true }

                    );
                    context.SaveChanges();
                }
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course { Id = 1, LecturerId = 3, Name = "Course 1", Code = "C1", Credit = 5, isActive = true },
                        new Course { Id = 2, LecturerId = 4, Name = "Course 2", Code = "C2", Credit = 6, isActive = true },
                        new Course { Id = 3, LecturerId = 3, Name = "Course 3", Code = "C3", Credit = 5, isActive = true },
                        new Course { Id = 4, LecturerId = 4, Name = "Course 4", Code = "C4", Credit = 6, isActive = true }

                    );
                    context.SaveChanges();
                }
                if (!context.Enrollments.Any())
                {
                    context.Enrollments.AddRange(
                        new Enrollment { Id = 1, CourseId = 1, StudentId = 1, isActive = true },
                        new Enrollment { Id = 2, CourseId = 2, StudentId = 1, isActive = true },
                        new Enrollment { Id = 3, CourseId = 3, StudentId = 1, isActive = true },
                        new Enrollment { Id = 4, CourseId = 4, StudentId = 1, isActive = true },
                        new Enrollment { Id = 5, CourseId = 1, StudentId = 2, isActive = true },
                        new Enrollment { Id = 6, CourseId = 2, StudentId = 2, isActive = true }

                    );
                    context.SaveChanges();
                }


            }
        }
    }
}
