using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                await _lecturerRepository.CreateLecturer(new Lecturer
                {
                    FirstName = lecturer.FirstName,
                    LastName = lecturer.LastName
                });
                return RedirectToAction("Index");
            }
            return View(lecturer);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecturer = await _lecturerRepository.Lecturers.FirstOrDefaultAsync(s => s.Id == id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                await _lecturerRepository.EditLecturer(lecturer);
                return RedirectToAction("Index");
            }
            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _lecturerRepository.DeleteLecturer((int)id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecturer = await _lecturerRepository.Lecturers.Include(x => x.Courses).FirstOrDefaultAsync(s => s.Id == id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }
    }

}