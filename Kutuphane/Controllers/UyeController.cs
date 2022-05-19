using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace Kutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        KutuphaneEntities1 db = new KutuphaneEntities1();
        public ActionResult Index( int say=1)
        {
            var uyeler = db.Uye.ToList().ToPagedList(say,5);
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uye uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uye.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int Id)
        {
            var u = db.Uye.Find(Id);
            db.Uye.Remove(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UyeGetir(int Id)
        {
            var u=db.Uye.Find(Id);
            return View("UyeGetir",u);

        }
        [HttpPost]
        public ActionResult UyeGetir(Uye uye)
        {
            var u=db.Uye.Find(uye.Id);
            u.Adi=uye.Adi;
            u.Soyadi=uye.Soyadi;    
            u.KullaniciAdi=uye.KullaniciAdi;
            u.EMail=uye.EMail;
            u.Telefon=uye.Telefon;
            u.Sifre=uye.Sifre;
            u.Fotograf=uye.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}