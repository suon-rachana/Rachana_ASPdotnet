using Microsoft.AspNetCore.Mvc;
namespace MyMvcApp.Controllers
{
  public class AboutController : Controller
  {
    public IActionResult Index()
    {
      ViewBag.CompanyName = "Angkor Techh Store";
      ViewBag.Address = "Siem Reap, Cambodia";
      ViewBag.Phone = "+855 123 456 789";
      return View();
    }
  }
}