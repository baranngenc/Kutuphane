using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;


namespace Kutuphane.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        KutuphaneEntities1 db = new KutuphaneEntities1();
        public ActionResult Index()
        {
            var a = db.Admin.ToList();
            return View(a);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int Id)
        {
            var a = db.Admin.Find(Id);
            db.Admin.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int Id)
        {
            var a = db.Admin.Find(Id);
            return View("AdminGetir", a);
        }
        [HttpPost]
        public ActionResult AdminGetir(Admin admin)
        {
            var a = db.Admin.Find(admin.Id);
            a.Adi = admin.Adi;
            a.Soyadi = admin.Soyadi;
            a.KullaniciAdi = admin.KullaniciAdi;
            a.Sifre = admin.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}