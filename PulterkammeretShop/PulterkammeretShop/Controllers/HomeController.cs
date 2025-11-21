using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PulterkammeretShop.Models;
using PulterkammeretShop.Helpers;
namespace PulterkammeretShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Katalog katalog;
    private static List<int> indkøbsKurv;
    public HomeController(ILogger<HomeController> logger)
    {
        if (indkøbsKurv == null)
        {
            indkøbsKurv = new List<int>();
        }
        _logger = logger;
    }
    //Program starts here :)
    public IActionResult Index()
    {
        if (katalog == null)
        {
            katalog = new Katalog();
        }
        return View();
    }
    public IActionResult Katalog()
    {
        
        Katalog katalog = new Katalog();
        List<Spil> SpilListe = katalog.HentSpilFraFil();
        return View(SpilListe);
    }

    [HttpPost]
    public IActionResult BuyItem(int spilId)
    {
        indkøbsKurv.Add(spilId);
        Debug.WriteLine(indkøbsKurv.Count); 
        return Redirect(@"Katalog");
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