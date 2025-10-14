using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class ThongBaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.ThongBaos.ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult GuiThongBao(ThongBao model)
        {
            if (ModelState.IsValid)
            {
                db.ThongBaos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult ChiTiet(string id)
        {
            var tb = db.ThongBaos.Find(id);
            return View(tb);
        }
    }
}