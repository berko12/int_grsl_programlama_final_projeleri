using Microsoft.AspNetCore.Mvc;
using Okul_Idare_Sistemi.Models;
using System.Diagnostics;

namespace Okul_Idare_Sistemi.Controllers
{
    public class HomeController : Controller
    {
         
        public IActionResult Index()
        {
            return View();
        }

      
    }
}