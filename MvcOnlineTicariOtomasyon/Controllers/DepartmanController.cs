using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Departmans.Where(x => x.Durum == true).ToList());
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmans.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = db.Departmans.Find(id);
            dep.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanGuncelle(int id)
        {
            var departman = db.Departmans.Find(id);
            if (departman == null) return HttpNotFound();
            return View(departman);

        }
        

        [HttpPost]
        public ActionResult DepartmanGuncelle (Departman departman)
        {
            if (ModelState.IsValid)         
                departman.Durum = true;
                db.Entry(departman).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index"); 
        }

        public ActionResult DepartmanDetay(int id)
        {
            var dpt = db.Departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(db.Personels.Where(x => x.Departmanid == id).ToList());
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = db.SatisHarakets.Where(x => x.Personelid == id).ToList();
            var per = db.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}