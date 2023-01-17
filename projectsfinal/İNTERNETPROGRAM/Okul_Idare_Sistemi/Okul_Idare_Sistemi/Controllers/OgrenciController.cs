using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okul_Idare_Sistemi.Data;
using Okul_Idare_Sistemi.Models;

namespace Okul_Idare_Sistemi.Controllers
{
    public class OgrenciController : Controller
    {
        DataContext _context = new DataContext();

        [HttpGet]
        public IActionResult Index()
        {

           var modelResult = _context.Ogrenciler.ToList();
            return View(modelResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var ogrenci =_context.Ogrenciler.Find(id);
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Update(Ogrenci model)
        {
            _context.Ogrenciler.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(Ogrenci model)
        {
            var ogrenci = _context.Ogrenciler.Find(model.Id);
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ogrenciValue =  _context.Ogrenciler.Find(id);
            _context.Ogrenciler.Remove(ogrenciValue);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
