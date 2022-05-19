 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneEntities1 db = new KutuphaneEntities1();
        public ActionResult Index()
        {
            var personel = db.Personel.ToList();
            return View(personel);

        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int Id)
        {
            var p = db.Personel.Find(Id);
            db.Personel.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGetir(int Id)
        {
            var p = db.Personel.Find(Id);

            return View("PersonelGetir",p);
        }
        [HttpPost]
        public ActionResult PersonelGetir(Personel p)
        {
            var per = db.Personel.Find(p.Id);
            per.Adi = p.Adi;
            per.Soyadi = p.Soyadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
