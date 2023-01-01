using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeyirAkademi_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace SeyirAkademi_v1._1.Controllers
{
    public class HomeController : Controller
    {
        private DocContext dContext = new DocContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Docs = dContext.Docs;
            return View(Docs);
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
                dContext.Add(d);
                dContext.SaveChanges();
                TempData["msj"] = d.Name + " adlı yazar eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Index");
            }
        }

        public IActionResult CreateDoc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDoc(Doc d)
        {
            if (ModelState.IsValid)
            {
                if(d.UploadImage != null)
                {
                    var dosyaUzanti = Path.GetExtension(d.UploadImage.FileName);
                    var dosyaAdi = Path.GetFileName(d.UploadImage.FileName);
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", d.Id + dosyaUzanti);
                    //var uzanti = "~/wwwroot/img/" + d.Id + dosyaUzanti;
                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    d.UploadImage.CopyTo(stream);
                    d.ImageURL = dosyaYolu;
                }
                if (d.UploadFile!= null)
                {
                    var dosyaUzanti = Path.GetExtension(d.UploadFile.FileName);
                    var dosyaAdi = Path.GetFileName(d.UploadFile.FileName);
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/file/", d.Id + dosyaUzanti);
                    //var uzanti = "~/wwwroot/img/" + d.Id + dosyaUzanti;
                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    d.UploadFile.CopyTo(stream);
                    d.ImageURL = dosyaYolu;
                }

                dContext.Add(d);
                dContext.SaveChanges();
                TempData["msj"] = d.Id + " adlı yazar eklendi";

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
