using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class HomeController : Controller
{
    public IActionResult ShopInfo()
    {
        string shopName = "Angkor Techh Store";
        string address = "123 Main Street, Phnom Penh, Cambodia";
        string phoneNumber = "+855 123 456 789";
        string openHours = "Monday to Saturday: 9:00 AM - 6:00 PM, Sunday: Closed";

        ViewBag.ShopName = shopName;
        ViewBag.Address = address;
        ViewBag.PhoneNumber = phoneNumber;
        ViewBag.OpenHours = openHours;

        return View();
    }
}
