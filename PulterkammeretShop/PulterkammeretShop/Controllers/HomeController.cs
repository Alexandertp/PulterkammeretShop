using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PulterkammeretShop.Models;
using PulterkammeretShop.Helpers;
namespace PulterkammeretShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Katalog katalog;
    private static List<Spil> indkøbsKurv;
    public static bool EmployeeLoggedIn = false;
    public HomeController(ILogger<HomeController> logger)
    {
        if (indkøbsKurv == null)
        {
            indkøbsKurv = new List<Spil>();
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

    public IActionResult Checkout()
    {
        
        return View(indkøbsKurv);
    }

    public IActionResult LogCustomer(string customerUserName, string customerPassword, int customerPhoneNumber, string customerAddress, string customerPaymentMethod)
    {
        bool isCustomerInSystem = false;
        Customer inputCustomer = new Customer(null, customerUserName, customerPassword,  customerPhoneNumber, customerAddress, customerPaymentMethod);
        AccountHelper accountHelper = new AccountHelper();
        foreach (Customer customer in accountHelper.listeMedAlleCustomers)
        {
            if (customerUserName == customer.name && customerPassword == customer.password &&
                customerPhoneNumber == customer.phoneNumber && customerAddress == customer.address &&
                customerPaymentMethod == customer.paymentInfo)
            {
                accountHelper.AddOrderToCustomerDirectory(customer, indkøbsKurv);
            }
        }

        if (isCustomerInSystem)
        {
            
        }
        return Redirect("Checkout");
    }

    public IActionResult Lager()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddToLager(string spilNavn, double spilPris, string spilKategori)
    {
        Katalog katalog = new Katalog();
        Spil nytSpilTilLager = new Spil(katalog.HentSpilFraFil().Count,spilNavn, spilPris, spilKategori);
        katalog.AddSpil(nytSpilTilLager);
        return Redirect("Lager");
    }

    public IActionResult LoginEmployee(string employeeUserName, string employeePassword)
    {
        AccountHelper accountHelper = new AccountHelper();
        foreach (Employee employee in accountHelper.listeMedAlleEmployees)
        {
            if (employeePassword == employee.password && employeeUserName == employee.name)
            {
                EmployeeLoggedIn = true;
            }
        }
        Debug.WriteLine("Employee Login er " + EmployeeLoggedIn);
        return Redirect($"Lager");
    }
    
    [HttpPost]
    public IActionResult BuyItem(int spilId)
    {
        katalog = new Katalog();
        List<Spil> SpilListe = katalog.HentSpilFraFil();
        if (indkøbsKurv.Exists(spil => spil.id == spilId))
        {
            foreach (Spil spil in indkøbsKurv)
            {
                if (spil.id == spilId)
                {
                    spil.antal++;
                }
            }
        }
        else
        {
            indkøbsKurv.Add(SpilListe.First(spil => spil.id == spilId));
        }
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