using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class NganHangMauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.NganHangMaus.ToList();
            return View(list);
        }

        public ActionResult ChiTiet(string id)
        {
            var bank = db.NganHangMaus.Find(id);
            return View(bank);
        }

        [HttpPost]
        public ActionResult CapNhatDanhSach(NganHangMau model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}