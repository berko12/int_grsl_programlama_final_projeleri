using Microsoft.AspNetCore.Mvc;
using Okul_Idare_Sistemi.Data;
using Okul_Idare_Sistemi.Models;

namespace Okul_Idare_Sistemi.Controllers
{
    public class YonetimController : Controller
    {
        DataContext _context = new DataContext();

        [HttpGet]
        public IActionResult Index()
        {

            var modelResult = _context.OkulYonetimler.ToList();
            return View(modelResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OkulYonetim model)
        {
            _context.OkulYonetimler.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var ogrenci = _context.OkulYonetimler.Find(id);
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Update(OkulYonetim model)
        {
            _context.OkulYonetimler.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(OkulYonetim model)
        {
            var okulYonetim = _context.OkulYonetimler.Find(model.Id);
            return View(okulYonetim);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var okulYonetim = _context.OkulYonetimler.Find(id);
            _context.OkulYonetimler.Remove(okulYonetim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

