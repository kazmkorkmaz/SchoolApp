using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;

namespace SchoolApp.Controllers
{
    public class LecturerController : Controller
    {
        private ILecturerRepository _lecturerRepository;
        public LecturerController(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _lecturerRepository.Lecturers.ToListAsync());
        }
    }
}