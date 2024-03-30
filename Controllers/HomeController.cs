using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }   
}