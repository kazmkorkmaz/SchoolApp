using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Data.Abstract;
using SchoolApp.Entity;
using SchoolApp.Models;

namespace SchoolApp.Controllers;

public class HomeController : Controller
{

    private IStudentRepository _studentRepository;
    private ILecturerRepository _lecturerRepository;
    private ICourseRepository _courseRepository;
    private IEnrollmentRepository _enrollmentRepository;


    public HomeController(IStudentRepository studentRepository, ILecturerRepository lecturerRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
    {
        _studentRepository = studentRepository;
        _lecturerRepository = lecturerRepository;
        _courseRepository = courseRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public IActionResult Index()
    {
        HomeViewModel homeViewModel = new HomeViewModel
        {
            StudentCount = _studentRepository.Students.Count(),
            LecturerCount = _lecturerRepository.Lecturers.Count(),
            CourseCount = _courseRepository.Courses.Count(),
            EnrolmentCount = _enrollmentRepository.Enrollments.Count(),

        };
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
