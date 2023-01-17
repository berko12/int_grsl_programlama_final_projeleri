using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Okul_Idare_Sistemi.Data;
using Okul_Idare_Sistemi.Models;

namespace Okul_Idare_Sistemi.Controllers
{
    public class DersController : Controller
    {
        DataContext _context = new DataContext();

        [HttpGet]
        public IActionResult Index()
        {
         
                
            var modelResult = _context.Dersler.Include(x => x.OkulYonetim).ToList();

            return View(modelResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> items = (from x in _context.OkulYonetimler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AdSoyad,
                                              Value = x.Id.ToString(),
                                          }).ToList();
            items.Insert(0, new SelectListItem()
            {
                Text = "Select",
                Value = string.Empty
            }); ;

            ViewBag.Item = items;          
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ders model)
        {

            var okulYonetimId = _context.OkulYonetimler.Where
              (x => x.Id == model.OkulYonetim.Id)
              .FirstOrDefault();
            model.OkulYonetim = okulYonetimId;
            _context.Dersler.Add(model);        
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> items = (from x in _context.OkulYonetimler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AdSoyad,
                                              Value = x.Id.ToString(),
                                          }).ToList();
            items.Insert(0, new SelectListItem()
            {
                Text = "Select",
                Value = string.Empty
            }); ;



            ViewBag.Item = items;
            var ogrenci = _context.Dersler.Find(id);
            return View(ogrenci);
        }
         

        [HttpPost]
        public IActionResult Update(Ders model)
        {
            var okulYonetimId = _context.OkulYonetimler.Where
             (x => x.Id == model.OkulYonetim.Id)
             .FirstOrDefault();
             model.OkulYonetim = okulYonetimId;
            _context.Dersler.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(Ders model)
        {
            var ogrenci = _context.Dersler.Find(model.Id);
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ogrenciValue = _context.Dersler.Find(id);
            _context.Dersler.Remove(ogrenciValue);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
