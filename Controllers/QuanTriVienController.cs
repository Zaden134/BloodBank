using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class QuanTriVienController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.QuanTriViens.ToList();
            return View(list);
        }

        public ActionResult QuanLyNguoiDung()
        {
            var users = db.NguoiDungs.ToList();
            return View(users);
        }

        public ActionResult TaoBaoCao()
        {
            // Giả sử bạn tạo báo cáo số lượng người hiến máu
            var baoCao = db.HienMaus.GroupBy(h => h.LoaiMau)
                .Select(g => new
                {
                    LoaiMau = g.Key,
                    TongLuong = g.Sum(x => x.LuongMauHien)
                }).ToList();

            return View(baoCao);
        }
    }
}