using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeyirAkademi_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Controllers
{
    public class HomeController : Controller
    {
        private DocContext dc = new DocContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(DocRepo.Docs);
        }
        public IActionResult DataCenterForEveryone()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DataCenterForCompany()
        {
            return View();
        }
        public IActionResult DataCenterForRD()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doc d)
        {
            if (ModelState.IsValid)
            {
                dc.Add(d);
                dc.SaveChanges();
                TempData["msj"] = d.Name + " adlı yazar eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Index");
            }
        }
        public IActionResult List()
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
