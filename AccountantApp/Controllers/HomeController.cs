using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountantApp.Models;
using AccountatApp.Domain.Entities;
using Domain;

namespace AccountantApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddWorkingHours()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWorkingHours(Project project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("WorkerName", "Required");
                ModelState.AddModelError("WorkingHoursOvertime", "Max 30 hours");
                return View("AddWorkingHours");
            }

            var OverTimeModifier = 1.5;
            var NightTimeModifier = 2;

            double wage = project.HourlyWage * (project.WorkingHoursNormal + OverTimeModifier * project.WorkingHoursOvertime + NightTimeModifier * project.WorkingHoursNight);
            project.Worker.Wage = wage;

            _context.Projects.Add(project);
            _context.SaveChanges();

            return View("ShowWage", project.Worker);
        }
        public IActionResult ShowWage(Worker worker)
        {
            return View(worker);
        }

        public IActionResult ShowWorkerList()
        {
            var workersList = _context.Workers.ToList();
            return View(workersList);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
