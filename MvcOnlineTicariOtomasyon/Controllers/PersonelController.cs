using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : BaseController
    {
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEKle()
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
            
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            db.Personels.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}