using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseRepository.Courses.Include(c => c.Lecturer).ToListAsync());
        }
    }
}