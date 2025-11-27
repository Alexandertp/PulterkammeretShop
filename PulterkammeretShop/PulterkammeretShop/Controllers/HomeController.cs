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
    public static Customer LoggedInUser;
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
    
    //TODO: Rename?
    /// <summary>
    /// Tilføjer en ordre til en fil på systemet
    ///
    /// Skrevet af Anne Sofie & Alexander
    /// </summary>
    /// <param name="customerUserName"></param>
    /// <param name="customerPassword"></param>
    /// <param name="customerPhoneNumber"></param>
    /// <param name="customerAddress"></param>
    /// <param name="customerPaymentMethod"></param>
    /// <returns></returns>
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
    
    /// <summary>
    ///
    ///
    /// Skrevet af Alexander
    /// </summary>
    /// <returns></returns>
    public IActionResult SeBestillinger()
    {
        AccountHelper accountHelper = new AccountHelper();
        if (LoggedInUser != null)
        {
        List<Ordre> ordreListe = accountHelper.ReadCustomerOrders(LoggedInUser.id);
        Debug.WriteLine(LoggedInUser.name);
        return View(ordreListe);
        }
        Debug.WriteLine("Bruger er ikke logget ind");
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
    [HttpPost]
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

    /// <summary>
    /// Skrevet af Alexander
    /// </summary>
    /// <param name="customerName"></param>
    /// <param name="customerPassword"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult LoginUser(string customerName, string customerPassword)
    {
        AccountHelper accountHelper = new AccountHelper();
        LoggedInUser = accountHelper.listeMedAlleCustomers.Where(x => x.name == customerName && x.password == customerPassword).FirstOrDefault();
        return Redirect("SeBestillinger");
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
    
    public IActionResult SearchResult(string searchQuery, string spilKategori)
    {

        Katalog katalog = new Katalog();
        List<Spil> newSearch = katalog.Search(searchQuery, spilKategori);
        return View(newSearch);
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