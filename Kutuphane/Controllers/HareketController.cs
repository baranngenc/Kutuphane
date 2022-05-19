using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
namespace Kutuphane.Controllers
{
    public class HareketController : Controller
    {
        // GET: Hareket
        KutuphaneEntities1 db=new KutuphaneEntities1();
        public ActionResult Index()
        {
            var h=db.Emanet.Where(x=>x.IslemDurum==true).ToList();
            return View(h);
        }
    }
}