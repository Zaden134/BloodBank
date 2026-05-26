using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // ==================== HÀM MÃ HOÁ MẬT KHẨU ====================
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        // ==================== LOGIN ====================
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

            string hashedPassword = HashPassword(model.Password);

            var user = db.NguoiDungs.FirstOrDefault(u =>
                u.Email == model.Email && u.Password == hashedPassword);

            if (user != null)
            {
                // ✅ Lưu session thông tin người dùng
                Session["UserEmail"] = user.Email;
                Session["UserRole"] = user.Role;
                Session["UserName"] = user.Ten;
                Session["UserId"] = user.IDNguoiDung;

                // ✅ Sau khi đăng nhập xong → quay về trang chủ
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            return View(model);
        }

        // ==================== REGISTER ====================
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (db.NguoiDungs.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email đã tồn tại trong hệ thống.");
                return View(model);
            }

            var hashedPassword = HashPassword(model.Password);

            var newUser = new NguoiDung
            {
                IDNguoiDung = Guid.NewGuid().ToString(),
                Ten = model.Ten,
                Email = model.Email,
                Password = hashedPassword,
                Role = model.Role,
                SDT = model.SDT
            };

            db.NguoiDungs.Add(newUser);
            db.SaveChanges();

            TempData["SuccessMessage"] = "🎉 Đăng ký tài khoản thành công!";
            ModelState.Clear();

            return RedirectToAction("Register");
        }

        // ==================== LOGOUT ====================
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
