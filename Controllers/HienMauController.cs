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

        // GET: HienMau (Danh sách tất cả)
        public ActionResult Index()
        {
            var list = db.HienMaus.ToList();
            return View(list);
        }

        // GET: HienMau/GhiNhan (Hiển thị form)
        public ActionResult GhiNhan()
        {
            return View();
        }

        // POST: HienMau/GhiNhan (Lưu dữ liệu từ form)
        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm attribute này để bảo mật
        public ActionResult GhiNhan(HienMau model)
        {
            if (ModelState.IsValid)
            {
                // Nếu IDMaHienMau cần tự động tạo, bạn có thể thêm logic ở đây
                // Ví dụ: model.IDMaHienMau = "HM" + Guid.NewGuid().ToString().Substring(0, 8);

                db.HienMaus.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Nếu có lỗi, trả về view với dữ liệu người dùng đã nhập
            return View(model);
        }

        // GET: HienMau/LichSu/5 (Xem lịch sử của một người)
        public ActionResult LichSu(string idNguoiHien)
        {
            if (string.IsNullOrEmpty(idNguoiHien))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var lichsu = db.HienMaus.Where(h => h.IDNguoiHien == idNguoiHien).ToList();

            // Lấy thông tin người dùng để hiển thị tên (nếu cần)
            ViewBag.NguoiHienID = idNguoiHien;

            return View(lichsu);
        }
    }
}