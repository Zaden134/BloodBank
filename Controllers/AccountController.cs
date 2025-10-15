using System;
using System.Linq;
using System.Web.Mvc;
using BloodBank.Models;
using System.Data.Entity;

namespace BloodBank.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // =================== LOGIN ===================
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = db.NguoiDungs.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                Session["UserEmail"] = user.Email;
                Session["UserRole"] = user.Role;
                Session["UserName"] = user.Ten;
                Session["UserId"] = user.IDNguoiDung;

                switch (user.Role)
                {
                    case "BỆNH VIỆN": return RedirectToAction("Index", "BenhVien");
                    case "NGƯỜI HIẾN": return RedirectToAction("Index", "NguoiHien");
                    case "NV NGÂN HÀNG MÁU": return RedirectToAction("Index", "NhanVien");
                    default: return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            return View(model);
        }

        // =================== REGISTER ===================
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Kiểm tra email trùng
            if (db.NguoiDungs.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email đã tồn tại trong hệ thống.");
                return View(model);
            }

            var newUser = new NguoiDung
            {
                IDNguoiDung = Guid.NewGuid().ToString(),
                Ten = model.Ten,
                Email = model.Email,
                Password = model.Password, // Có thể hash nếu muốn bảo mật
                Role = model.Role,
                SDT = model.SDT
            };

            db.NguoiDungs.Add(newUser);
            db.SaveChanges(); // ← lưu vào database

            // Tự động login
            Session["UserEmail"] = newUser.Email;
            Session["UserRole"] = newUser.Role;
            Session["UserName"] = newUser.Ten;
            Session["UserId"] = newUser.IDNguoiDung;

            return RedirectToAction("Index", "Home");
        }

        // =================== LOGOUT ===================
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
