using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        private ILecturerRepository _lecturerRepository;
        public CourseController(ICourseRepository courseRepository, ILecturerRepository lecturerRepository)
        {
            _courseRepository = courseRepository;
            _lecturerRepository = lecturerRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseRepository.Courses.Include(c => c.Lecturer).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            FillSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.CreateCourse(course);
                return RedirectToAction("Index");

            }
            FillSelectList(course);
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _courseRepository.Courses.FirstOrDefaultAsync(s => s.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            FillSelectList(course);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.EditCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _courseRepository.Courses.Include(x => x.Enrollments).ThenInclude(x => x.Student).FirstOrDefaultAsync(s => s.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _courseRepository.DeleteCourse((int)id);
            return RedirectToAction("Index");
        }

        public void FillSelectList(Course course = null!)
        {
            ViewBag.LecturerItems = new SelectList(_lecturerRepository.Lecturers.Select(l => new { Id = l.Id, FullName = $"{l.FirstName} {l.LastName}" }), "Id", "FullName", course != null ? course.LecturerId : null);
        }
    }
}