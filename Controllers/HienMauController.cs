using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class HienMauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.HienMaus.ToList();
            return View(list);
        }

        public ActionResult GhiNhan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GhiNhan(HienMau model)
        {
            if (ModelState.IsValid)
            {
                db.HienMaus.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult LichSu(string idNguoiHien)
        {
            var lichsu = db.HienMaus.Where(h => h.IDNguoiHien == idNguoiHien).ToList();
            return View(lichsu);
        }
    }
}