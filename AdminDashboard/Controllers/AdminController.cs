using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;

namespace AdminDashboard.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                Stats = new List<StatCard>
                {
                    new StatCard { Label = "Total students", Value = "1,284", Delta = "+4.2%", IsPositive = true },
                    new StatCard { Label = "Active courses",  Value = "36",    Delta = "+2",    IsPositive = true },
                    new StatCard { Label = "Pending approvals", Value = "8",   Delta = "-3",    IsPositive = true },
                    new StatCard { Label = "Overdue fees",    Value = "$2,140", Delta = "+12%", IsPositive = false }
                },
                RecentActivity = new List<ActivityLog>
                {
                    new ActivityLog { Actor = "Sok Dara",      Action = "Enrolled in Advanced Web Application Development", When = DateTime.Now.AddMinutes(-12) },
                    new ActivityLog { Actor = "Chan Vichea",   Action = "Submitted Mobile Programming II assignment",       When = DateTime.Now.AddHours(-2) },
                    new ActivityLog { Actor = "Lim Sreyneang", Action = "Updated profile photo",                            When = DateTime.Now.AddHours(-5) },
                    new ActivityLog { Actor = "Kong Piseth",   Action = "Paid Term 1 tuition",                              When = DateTime.Now.AddDays(-1) }
                },
                MonthLabels = new List<string> { "Feb", "Mar", "Apr", "May", "Jun", "Jul" },
                EnrollmentsByMonth = new List<int> { 142, 168, 155, 203, 231, 248 }
            };

            return View(model);
        }

        public IActionResult Users()
        {
            var users = new List<UserAccount>
            {
                new UserAccount { Id = 1, FullName = "Sok Dara",      Email = "dara.sok@campus.edu.kh",     Role = "Student",   Status = "Active",    JoinedOn = new DateTime(2024, 9, 14) },
                new UserAccount { Id = 2, FullName = "Chan Vichea",   Email = "vichea.chan@campus.edu.kh",  Role = "Student",   Status = "Active",    JoinedOn = new DateTime(2024, 9, 14) },
                new UserAccount { Id = 3, FullName = "Lim Sreyneang", Email = "sreyneang.lim@campus.edu.kh", Role = "Lecturer", Status = "Active",    JoinedOn = new DateTime(2023, 2, 1) },
                new UserAccount { Id = 4, FullName = "Kong Piseth",   Email = "piseth.kong@campus.edu.kh",  Role = "Student",   Status = "Pending",   JoinedOn = new DateTime(2026, 6, 30) },
                new UserAccount { Id = 5, FullName = "Meas Sophea",   Email = "sophea.meas@campus.edu.kh",  Role = "Registrar", Status = "Active",    JoinedOn = new DateTime(2022, 11, 8) },
                new UserAccount { Id = 6, FullName = "Ny Chanthou",   Email = "chanthou.ny@campus.edu.kh",  Role = "Student",   Status = "Suspended", JoinedOn = new DateTime(2025, 1, 20) }
            };

            return View(users);
        }


        public IActionResult Reports()
        {
            return View();
        }
    }
}
