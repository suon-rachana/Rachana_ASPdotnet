using Microsoft.AspNetCore.Mvc;
using MvcExercises.Models;

namespace MvcExercises.Controllers
{
    // លំហាត់ 5.5 (DepartmentStaff)
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            // Build a Department object in the Action
            var department = new Department
            {
                Id = 1,
                Name = "Information Technology",
                StaffMembers = new List<string>
                {
                    "Sok Dara",
                    "Chan Vichea",
                    "Lim Sreyneang",
                    "Kong Piseth"
                }
            };

            // Pass to the Strongly-typed View
            return View(department);
        }
    }
}
