using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        KutuphaneEntities1 db = new KutuphaneEntities1();
        // GET: Yazar
        public ActionResult Index()
        {
            var y = db.Yazar.ToList();
            return View(y);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
       [HttpPost]
        public ActionResult YazarEkle( Yazar yazar)
        {
            
            db.Yazar.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int Id)
        {
            var Sil = db.Yazar.Find(Id);
            db.Yazar.Remove(Sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YazarGetir(int Id)
        {
            var Bul=db.Yazar.Find(Id);

            return View("YazarGetir",Bul);

        }
        [HttpPost]
        public ActionResult YazarGetir(Yazar yazar)
        {
            var y = db.Yazar.Find(yazar.Id);
            y.Adi = yazar.Adi;
            y.Soyadi = yazar.Soyadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
