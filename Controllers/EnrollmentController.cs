using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;

namespace SchoolApp.Controllers
{
    public class EnrollmentController : Controller
    {
        private IEnrollmentRepository _enrollmentRepository;
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _enrollmentRepository.Enrollments.Include(c => c.Course).Include(s => s.Student).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            FillSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentRepository.CreateEnrollment(enrollment);
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var enrollment = await _enrollmentRepository.Enrollments.FirstOrDefaultAsync(s => s.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            FillSelectList(enrollment);
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentRepository.EditEnrollment(enrollment);
                return RedirectToAction("Index");
            }
            FillSelectList(enrollment);
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _enrollmentRepository.DeleteEnrollment((int)id);
            return RedirectToAction("Index");
        }
        public void FillSelectList(Enrollment enrollment = null!)
        {
            ViewBag.CourseItems = new SelectList(_courseRepository.Courses.Select(l => new { CourseId = l.Id, FullName = $"{l.Code} - {l.Name}" }), "CourseId", "FullName", enrollment != null ? enrollment.CourseId : null);
            ViewBag.StudentItems = new SelectList(_studentRepository.Students.Select(l => new { StudentId = l.Id, FullName = $"{l.FirstName} - {l.LastName}" }), "StudentId", "FullName", enrollment != null ? enrollment.StudentId : null);


        }
    }
}