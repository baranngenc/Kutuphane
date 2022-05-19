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
        public ActionResult Index()
        {
         AnasayfaListeleme anasayfaListeleme = new AnasayfaListeleme();
           anasayfaListeleme.kitap=db.Kitap.ToList();
            anasayfaListeleme.iletisim=db.Iletisim.ToList();
            return View(anasayfaListeleme);
        }
        [HttpPost]
        public ActionResult Index(Iletisim i)
        {
            db.Iletisim.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}