using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PulterkammeretShop.Models;

namespace PulterkammeretShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        Costumer bob = new Costumer();
        bob.addToOrder(0, "Order1");
        return View();
    }

    public IActionResult Katalog() => View();

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