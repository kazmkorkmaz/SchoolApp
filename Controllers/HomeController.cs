using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Entites;
using SchoolApp.Models;

namespace SchoolApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SchoolAppDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, SchoolAppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        HomeViewModel homeViewModel = new HomeViewModel
        {
            StudentCount = _dbContext.Students.Count(),
            LecturerCount = _dbContext.Lecturers.Count(),
            CourseCount = _dbContext.Courses.Count(),
            EnrolmentCount = _dbContext.Enrollments.Count(),

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
