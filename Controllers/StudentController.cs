using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _studentRepository.Students.ToListAsync());
        }
    }
}