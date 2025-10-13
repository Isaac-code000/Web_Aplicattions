using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers;

public class DepartmentsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}