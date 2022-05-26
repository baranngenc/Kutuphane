using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using Kutuphane.Controllers;

namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        //  KutuphaneEntities1 KutuphaneEntities = new KutuphaneEntities1();

         KutuphaneEntities1 KutuphaneEntities = new KutuphaneEntities1();
        public ActionResult Index()
        {
            var deger = KutuphaneEntities.Kategori.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            
            KutuphaneEntities.Kategori.Add(kategori);
            KutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int Id)
        {
            var Silme = KutuphaneEntities.Kategori.Find(Id);
            KutuphaneEntities.Kategori.Remove(Silme);
            KutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGetir(int Id)
        {
            var Bul = KutuphaneEntities.Kategori.Find(Id);
            return View("KategoriGetir",Bul);
        }
        [HttpPost]
        public ActionResult KategoriGetir(Kategori kategori)
        {
            var k = KutuphaneEntities.Kategori.Find(kategori.Id);
            k.Adi = kategori.Adi;
            KutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}