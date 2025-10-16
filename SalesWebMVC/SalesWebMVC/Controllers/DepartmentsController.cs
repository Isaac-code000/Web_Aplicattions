
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers;

public class DepartmentsController : Controller
{
    // GET
    public IActionResult Index()
    {
        List<Department> departments = new List<Department>();  
        departments.Add(new Department{Id = 1, Name = "c32"});
        departments.Add(new Department{Id = 2, Name = "c37"});   
        
        return View(departments);
    }
}