using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : BaseController
    {
        TicariOtomasyonDbContext c = new TicariOtomasyonDbContext();
        public ActionResult Index()
        {
            var c= db.Kategoris.ToList();
            return View(c);
        }


        [HttpGet]//form ilk çalıştıgında bu kısım çalışır
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]//bur butona basıldıgında burası çalışır
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil (int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle (Kategori k)
        {
            var kate = c.Kategoris.Find(k.KategoriID);
            kate.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 