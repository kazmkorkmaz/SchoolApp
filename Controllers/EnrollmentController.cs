using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;

namespace SchoolApp.Controllers
{
    public class EnrollmentController : Controller
    {
        private IEnrollmentRepository _enrollmentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            foreach (var item in _enrollmentRepository.Enrollments.Include(s => s.Student))
            {
                Console.WriteLine(item.Student);
            }
            return View(await _enrollmentRepository.Enrollments.Include(c => c.Course).Include(s => s.Student).ToListAsync());
        }
    }
}