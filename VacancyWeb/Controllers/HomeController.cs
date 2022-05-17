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

        public IActionResult HowItWork()
        {
            return View();
        }
        public IActionResult SendRequest(int id, string LastName, string FirstName, string MiddleName, string Phone,
            string Email)
        {
            VacancyRequest vr = db.VacancyRequests.SingleOrDefault(c => c.Id == id);
            if (vr is null)
                return BadRequest("Ой, похоже что-то не так с данными");
            Request req = new Request
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                Phone = Phone,
                Vacancy = vr.Id, 
                Status = 1
            };
            db.Requests.Add(req);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Заявка отправлена');</script>";
            return RedirectToAction("SingleVacancy", new {id = vr.Id});
        }
        public IActionResult Vacancies(string title, string salary, int type, int[] typeOfEmployments, int[] timeTables, int? page, int? vacanOnPage)
        {
            if (vacanOnPage is null)
                vacanOnPage = 5;
            
            if (page is null)
                page = 1;
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
                ListsStaves = db.staff.ToList(),
                AllListVacancyRequests = db.VacancyRequests.ToList()
            };
            if (!string.IsNullOrEmpty(title))
            {
                fw.ListVacancyRequests = db.VacancyRequests.Where(c => c.Title.Contains(title)).ToList();
            }

            if (!string.IsNullOrEmpty(salary))
            {
                fw.ListVacancyRequests = fw.ListVacancyRequests.Where(c => c.SalaryMin > int.Parse(salary)).ToList();
            }
            if (type != 0)
            {
                fw.ListVacancyRequests = fw.ListVacancyRequests.Where(c => c.Type == type).ToList();
            }

            if (typeOfEmployments.Length > 0)
            {
                if (typeOfEmployments[0] != 0)
                {
                    List<VacancyRequest> lvr = fw.ListVacancyRequests;
                    fw.ListVacancyRequests = new List<VacancyRequest>();
                    for (int i = 0; i < typeOfEmployments.Length; i++)
                    {
                        fw.ListVacancyRequests.AddRange(lvr.Where(c => c.TypeOfEmployment == typeOfEmployments[i]).ToList());
                    }

                }
            }
            if (timeTables.Length > 0)
            {
                if (timeTables[0] != 0)
                {
                    List<VacancyRequest> lvr = fw.ListVacancyRequests;
                    fw.ListVacancyRequests = new List<VacancyRequest>();
                    for (int i = 0; i < timeTables.Length; i++)
                    {
                        fw.ListVacancyRequests.AddRange(lvr.Where(c => c.TimeTable == timeTables[i]).ToList());
                    }

                }
            }

            fw.ListVacancyRequests = fw.ListVacancyRequests.OrderByDescending(c => c.Date).ToList();
            int maxPage = 0;
            if (fw.ListVacancyRequests.Count % (int)vacanOnPage == 0)
            {
                maxPage = fw.ListVacancyRequests.Count / (int)vacanOnPage;
            }
            else
            {
                if (fw.ListVacancyRequests.Count < (int)vacanOnPage)
                    maxPage = 1;
                else
                {
                    maxPage = fw.ListVacancyRequests.Count / (int)vacanOnPage + 1;
                }
                
            }
            if (fw.ListVacancyRequests.Count - (int)vacanOnPage * (page - 1) > (int)vacanOnPage)
            {
                fw.ListVacancyRequests = fw.ListVacancyRequests.GetRange((int)vacanOnPage * ((int) page - 1), (int)vacanOnPage);
            }
            else
            {
                int count = fw.ListVacancyRequests.Count - (int)vacanOnPage * ((int) page - 1);
                fw.ListVacancyRequests = fw.ListVacancyRequests.GetRange((int)vacanOnPage * ((int)page - 1), count);
            }
            

            
            
            FilterClass fc = new FilterClass
            {
                Type = type,
                Title = title,
                TypeOfEmployment = typeOfEmployments,
                Page = (int)page,
                Salary = salary,
                TimeTables = timeTables,
                PageMax = maxPage,
                VacancyOnPage = (int)vacanOnPage
            };
            fw.Filter = fc;
            return View(fw);
        }

        public IActionResult About()
        {
            return View();
        }

       

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult SingleVacancy(int id)
        {
            VacancyRequest vr = db.VacancyRequests.SingleOrDefault(c => c.Id == id);
            if (vr is null)
                return NotFound();
            ForViewSingle fvs = new ForViewSingle
            {
                VacancyRequests = vr,
                ListConditions = db.Conditions.Where(c=> c.VacancyId == vr.Id).ToList(),
                Staves = db.staff.SingleOrDefault(c=> c.Id == vr.Staff),
                ListDuties = db.Duties.Where(c => c.VacancyId == vr.Id).ToList(),
                TimeTables = db.TimeTables.SingleOrDefault(c=> c.Id == vr.TimeTable),
                TypeOfEmployments = db.TypeOfEmployments.SingleOrDefault(c=> c.Id == vr.TypeOfEmployment),
                TypeVacancies = db.TypeVacancies.SingleOrDefault(c=> c.Id == vr.Type),
                ListRequirements = db.Requirements.Where(c => c.VacancyId == vr.Id).ToList()
            };
            return View(fvs);
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
