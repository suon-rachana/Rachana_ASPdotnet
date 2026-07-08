using Microsoft.AspNetCore.Mvc;
using MvcExercises.Models;

namespace MvcExercises.Controllers
{
    // លំហាត់ 5.6 (DoctorSchedule)
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            // Build a List of 2 Doctors in the Action
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Sovann Rith",
                    Specialty = "Cardiology",
                    AvailableDays = new List<string> { "Monday", "Wednesday", "Friday" }
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Dr. Mao Sokha",
                    Specialty = "Pediatrics",
                    AvailableDays = new List<string> { "Tuesday", "Thursday", "Saturday" }
                }
            };

            // Pass the List to the View
            return View(doctors);
        }
    }
}
