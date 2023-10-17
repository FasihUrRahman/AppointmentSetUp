using Appoinment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHospital _hospital;

        public HomeController(ILogger<HomeController> logger, IHospital hospital)
        {
            _logger = logger;
            _hospital = hospital;
        }

        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Doctor = _hospital.GetDoctors();
            mymodel.Patient = _hospital.GetPatients();
            return View(mymodel);
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
}