using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VacancyWeb.Models;

namespace VacancyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        VacancyContext db = new VacancyContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ForView fw = new ForView
            {
                ListVacancyRequests = db.VacancyRequests.ToList(),
                ListDuties = db.Duties.ToList(),
                ListTypeVacancies = db.TypeVacancies.ToList(),
                ListConditions = db.Conditions.ToList(),
                ListRequirements = db.Requirements.ToList(),
                ListTypeOfEmployments = db.TypeOfEmployments.ToList(),
                ListTimeTables = db.TimeTables.ToList(),
                ListRequests = db.Requests.ToList(),
                ListsStaves = db.staff.ToList()
            };
            return View(fw);
        }
        public IActionResult Vacancies()
        {
            return View();
        }
        public IActionResult SingleVacancy()
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
    }
}
