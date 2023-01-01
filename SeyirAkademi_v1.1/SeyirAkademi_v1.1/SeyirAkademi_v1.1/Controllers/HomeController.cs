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
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

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
        public async Task<IActionResult> DataCenterForEveryone()
        {
            List<Doc> y = new List<Doc>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44327/api/DocsApi/0");
            string resString = await response.Content.ReadAsStringAsync();
            y = JsonConvert.DeserializeObject<List<Doc>>(resString);

            //var y = dContext.Docs.Where(x => x.DocTypeId == 0);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir doküman bulunamadı";
               return View("Hata");
            }
            return View(y);
        }

        [Authorize]
        public async Task<IActionResult> DataCenterForCompany()
        {
            List<Doc> y = new List<Doc>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44327/api/DocsApi/1");
            string resString = await response.Content.ReadAsStringAsync();
            y = JsonConvert.DeserializeObject<List<Doc>>(resString);

            //var y = dContext.Docs.Where(x => x.DocTypeId == 1);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir doküman bulunamadı";
                return View("Hata");
            }
            return View(y);
        }

        [Authorize(Roles = "RdUser,Admin")]
        public async Task<IActionResult> DataCenterForRD()
        {
            List<Doc> y = new List<Doc>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44327/api/DocsApi/2");
            string resString = await response.Content.ReadAsStringAsync();
            y = JsonConvert.DeserializeObject<List<Doc>>(resString);
            //var y = dContext.Docs.Where(x => x.DocTypeId == 2);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir doküman bulunamadı";
                return View("Hata");
            }
            return View(y);
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
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", d.UploadImage.FileName);
                    //var uzanti = "~/wwwroot/img/" + d.Id + dosyaUzanti;
                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    d.UploadImage.CopyTo(stream);
                    d.ImageURL = Path.Combine("/img/", d.UploadImage.FileName);
                }
                if (d.UploadFile!= null)
                {
                    var dosyaUzanti = Path.GetExtension(d.UploadFile.FileName);
                    var dosyaAdi = Path.GetFileName(d.UploadFile.FileName);
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/file/", d.UploadFile.FileName);
                    //var uzanti = "~/wwwroot/img/" + d.Id + dosyaUzanti;
                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    d.UploadFile.CopyTo(stream);
                    d.FileURL = Path.Combine("/file/", d.UploadFile.FileName); ;
                }

                dContext.Add(d);
                var result = dContext.SaveChanges();

                TempData["msj"] = d.Id + " adlı yazar eklendi";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Index");
            }
        }

        public IActionResult DocDetail(int id)
        {

            return View(dContext.Docs.FirstOrDefault(x => x.Id == id));
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
