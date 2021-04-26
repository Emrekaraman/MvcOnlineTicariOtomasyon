using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : BaseController
    {
        public ActionResult Index()
        {
            var urunler = db.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriID", "KategoriAd");
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            if (ModelState.IsValid)
            {
                p.Durum = true;
                db.Uruns.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriID", "KategoriAd");
            return View();
        }

        public ActionResult UrunSil(int id)
        {
            var deger = db.Uruns.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Duzenle(int id)
        {
            var urun = db.Uruns.Find(id);
            if (urun == null) return HttpNotFound();
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriID", "KategoriAd");
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Urun urun)
        {
          
            if (ModelState.IsValid)
            {
                urun.Durum = true;
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Urunid = new SelectList(db.Kategoris, "KategoriID", "KategoriAd");
            return View(urun);
        }


    }
}