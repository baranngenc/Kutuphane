using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       KutuphaneEntities1 db=new KutuphaneEntities1();
        public ActionResult GirisYap()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult GirisYap(Admin admin)
        {
            var g=db.Admin.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre==admin.Sifre);
            if (g != null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAdi, false);
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
               return View();
            }
            
        }
       
    }
}