using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Okul_Idare_Sistemi.Data;
using Okul_Idare_Sistemi.Models;

namespace Okul_Idare_Sistemi.Controllers
{
    public class OgrenciDersController : Controller
    {
        DataContext _context = new DataContext();
        public IActionResult Index()
        {
            var modelResult = _context.OgrenciDersler.Include(x => x.Ogrenci).Include(x => x.Ders).ToList();
            return View(modelResult);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> Oitems = (from x in _context.Ogrenciler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AdSoyad,
                                              Value = x.Id.ToString(),
                                          }).ToList();
            Oitems.Insert(0, new SelectListItem()
            {
                Text = "Select",
                Value = string.Empty
            }); ;

            ViewBag.OItem = Oitems;
            List<SelectListItem> Ditems = (from x in _context.Dersler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.Id.ToString(),
                                           }).ToList();
            Ditems.Insert(0, new SelectListItem()
            {
                Text = "Select",
                Value = string.Empty
            }); ;

            ViewBag.DItem = Ditems;
            return View();
        }

        [HttpPost]
        public IActionResult Create(OgrenciDers model)
        {

            var ogrenciId = _context.Ogrenciler.Where
              (x => x.Id == model.Ogrenci.Id)
              .FirstOrDefault();
            var dersId = _context.Dersler.Where
              (x => x.Id == model.Ders.Id)
              .FirstOrDefault();
            model.Ogrenci = ogrenciId;
            model.Ders = dersId;
            _context.OgrenciDersler.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(OgrenciDers model)
        {
            var modelResult = _context.OgrenciDersler.Include(x => x.Ogrenci).Include(x => x.Ders).ToList();
            var OgrenciDersId = _context.OgrenciDersler.Find(model.Id);         
            return View(OgrenciDersId);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var OgrenciDersId = _context.OgrenciDersler.Find(id);
            _context.OgrenciDersler.Remove(OgrenciDersId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
