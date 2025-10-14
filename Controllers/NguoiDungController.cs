using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBank.Models;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class NguoiDungController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NguoiDung/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string email, string password)
        {
            var user = db.NguoiDungs.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
            return View();
        }

        // GET: NguoiDung/DangKy
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(NguoiDung model)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return View(model);
        }

        // GET: NguoiDung/CapNhatThongTin
        public ActionResult CapNhatThongTin(string id)
        {
            var user = db.NguoiDungs.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult CapNhatThongTin(NguoiDung model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile", new { id = model.IDNguoiDung });
            }
            return View(model);
        }
    }
}