using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using Kutuphane.Models.classes;

namespace Kutuphane.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        KutuphaneEntities1 db = new KutuphaneEntities1();
        [HttpGet]
        //[Authorize]
        
        public ActionResult Index()
        {
            
            var uyesayisi=db.Uye.Count();
            ViewBag.us = uyesayisi;
            var kitapsayisi=db.Kitap.Count();
            ViewBag.ks = kitapsayisi;
            var personelsayisi = db.Personel.Count();
            ViewBag.ps = personelsayisi;
            

            AnasayfaListeleme anasayfaListeleme = new AnasayfaListeleme();
            return View(anasayfaListeleme);
        }
        [HttpPost]
        public ActionResult Index(Kitap kitap)
        {
           
            
            return RedirectToAction("Index");
        }



    }
}