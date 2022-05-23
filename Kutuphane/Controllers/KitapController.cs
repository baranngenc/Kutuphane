using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Sql;
using Kutuphane.Models.Entity;
using System.Data.SqlClient;
using Kutuphane.Models;
using System.Data.Entity;
namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KutuphaneEntities1 db = new KutuphaneEntities1();
        public ActionResult Index(string k)
        {
            var Kitaplar = from ktp in db.Kitap select ktp;

            List<Kitap> list = new List<Kitap>();
            Kitap kitap = new Kitap();  
Kategori kategori = new Kategori();
        



            foreach (var item in Kitaplar)
            {
                item.Yazar = db.Yazar.FirstOrDefault(x => x.Id == item.YazarId);
                item.Kategori = db.Kategori.FirstOrDefault(x => x.Id == item.KategoriId);

                kitap = item;   
                list.Add(kitap);
            }

            if (!string.IsNullOrEmpty(k))
            {
                list = (List<Kitap>)list.Where(x => x.Adi.Contains(k));
            }

            return View(list.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> Ktgr = (from k in db.Kategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = k.Adi,
                                             Value = k.Id.ToString()
                                         }).ToList();
            ViewBag.kategori = Ktgr;

            List<SelectListItem> yazar = (from y in db.Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.Adi + " " + y.Soyadi,
                                              Value = y.Id.ToString()
                                          }
                                        ).ToList();
            ViewBag.yzr = yazar;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                KitapEkle();
                //ViewBag.kategori = new SelectList(db.Kitap, "KategoriId");
                //ViewBag.yzr = new SelectList(db.Kitap, "YazarId");
                return View("KitapEkle");
            }
            var ktgri = db.Kategori.Where(k => k.Id ==kitap.Kategori.Id).FirstOrDefault();
            var yazr = db.Yazar.Where(y => y.Id == kitap.Yazar.Id).FirstOrDefault();
            kitap.Kategori = ktgri;
            kitap.Yazar = yazr;
            db.Kitap.Add(kitap);
            db.Kategori.Add(ktgri);
            db.Yazar.Add(yazr); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int Id)
        {
            var k = db.Kitap.Find(Id);
            db.Kitap.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KitapGetir(int Id)
        {
            List<SelectListItem> Ktgr = (from k in db.Kategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = k.Adi,
                                             Value = k.Id.ToString()
                                         }).ToList();
            ViewBag.ktg = Ktgr;

            List<SelectListItem> yazar = (from y in db.Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.Adi + " " + y.Soyadi,
                                              Value = y.Id.ToString()
                                          }
                                        ).ToList();
            ViewBag.yzr = yazar;
            var kitap=db.Kitap.Find(Id);
            db.SaveChanges();
            return View("KitapGetir",kitap);
            
        }
        [HttpPost]
        public ActionResult KitapGetir(Kitap kitap )
        {
            var k = db.Kitap.Find(kitap.Id);
            k.Adi=kitap.Adi;
            k.SayfaSayisi = kitap.SayfaSayisi;
            k.Yayinevi=kitap.Yayinevi;
            k.BasimYili= kitap.BasimYili;
            k.Durum=kitap.Durum;
            var ktgr=db.Kategori.Where(x => x.Id==kitap.Kategori.Id).FirstOrDefault();
            k.Kategori=ktgr;
            var yzr = db.Yazar.Where(y => y.Id == kitap.Yazar.Id).FirstOrDefault();
            k.Yazar=yzr;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}