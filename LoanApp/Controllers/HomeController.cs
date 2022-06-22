using LoanApp.Models;
using LoanApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoanApp.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ScoreCalculation _scoreCalculation;
    //private readonly CustomerService _customerService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _scoreCalculation = new ScoreCalculation();
        //_customerService = new CustomerService();
    }

    public IActionResult Index()
    {
        return View();
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

    [HttpGet]
    public IActionResult GetCredit()
    {
        var model = new CreditApplication();
        model.Customer = new Customer();
        model.Customer.FamilyMamber = new List<Customer>();
        model.Customer.Errors = new Dictionary<string, string>();

        return View(model);
    }

    [HttpPost]
    public IActionResult GetCredit(CreditApplication model)
    {
        if (!CustomerService.ValidationOfCustomer(model.Customer))
        {
            model.Customer.HaveFamilyMamber = false;
            return View(model);
        }

        var result = _scoreCalculation.Result(model);

        if (result)
        {
            return View("Success");
        }
        else
        {
            return View("Failure");
        }
    }
}