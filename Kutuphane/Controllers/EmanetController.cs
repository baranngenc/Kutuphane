using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Kutuphane.Models.Entity;
using Kutuphane.Controllers;

namespace Kutuphane.Controllers
{
    public class EmanetController : Controller
    {
        // GET: Emanet
        KutuphaneEntities1 Db=new KutuphaneEntities1();
        


        public ActionResult Index()
        {
            var e = Db.Emanet.Where(x=>x.IslemDurum==false).ToList();
            return View(e);
        }
        [HttpGet]
        public ActionResult EmanetVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmanetVer(Emanet emanet)
        {
            if (!ModelState.IsValid)
            {
                return View("EmanetVer");
            }

            Db.Emanet.Add(emanet);
                Db.SaveChanges();
                return View();
            
           
        }
        public ActionResult EmanetSil(int Id)
        {
            var sil = Db.Emanet.Find(Id);
            Db.Emanet.Remove(sil);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult EmanetGetir(Emanet emanet)
        {
            var e= Db.Emanet.Find(emanet.Id);
            DateTime tt = DateTime.Parse(e.IadeTarihi.ToString());
            DateTime bg = DateTime.Parse(DateTime.Now.ToString());
            TimeSpan Ct=bg-tt;
            ViewBag.Ceza = Ct.TotalDays;
            return View("Emanetİade", e);
        }
        
        public ActionResult Emanetİade (Emanet em)
        {
            var ek = Db.Emanet.Find(em.Id);
            ek.TeslimTarihi = em.TeslimTarihi; 
            ek.Kitap.Durum = true;
            ek.IslemDurum=true;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}