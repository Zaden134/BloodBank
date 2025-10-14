using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class YeuCauMauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.YeuCauMaus.ToList();
            return View(list);
        }

        public ActionResult TaoMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoMoi(YeuCauMau model)
        {
            if (ModelState.IsValid)
            {
                model.TrangThai = "Chờ";
                db.YeuCauMaus.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult DuyetYeuCau(string id)
        {
            var yc = db.YeuCauMaus.Find(id);
            yc.TrangThai = "Đã phê duyệt";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TuChoiYeuCau(string id)
        {
            var yc = db.YeuCauMaus.Find(id);
            yc.TrangThai = "Đã từ chối";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}