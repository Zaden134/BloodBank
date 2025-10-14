using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class ThongBaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ThongBao (Hiển thị danh sách)
        public ActionResult Index()
        {
            var thongBaos = db.ThongBaos.ToList();
            return View(thongBaos);
        }

        // GET: ThongBao/Details/5 (Xem chi tiết)
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // GET: ThongBao/Create (Hiển thị form tạo mới)
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongBao/Create (Lưu dữ liệu)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDThongBao,TinNhan,IDNguoiNhanTT,ThongBaoLoaiMau")] ThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                db.ThongBaos.Add(thongBao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongBao);
        }

        // GET: ThongBao/Edit/5 (Hiển thị form sửa)
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // POST: ThongBao/Edit/5 (Lưu thay đổi)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDThongBao,TinNhan,IDNguoiNhanTT,ThongBaoLoaiMau")] ThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongBao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongBao);
        }

        // GET: ThongBao/Delete/5 (Hiển thị form xác nhận xóa)
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // POST: ThongBao/Delete/5 (Thực hiện xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongBao thongBao = db.ThongBaos.Find(id);
            db.ThongBaos.Remove(thongBao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}