using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : BaseController
    {
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = db.Carilers.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniCari");
            }
            p.Durum = true;
            db.Carilers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cr = db.Carilers.Find(id);
            cr.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = db.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid) { 
                return View("CariGetir");
            }
            var cari = db.Carilers.Find(cariler.Cariid );
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSehir = cariler.CariSehir;
            cari.CariMail = cariler.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = db.SatisHarakets.Where(x => x.Cariid == id).ToList();
            var cr = db.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}