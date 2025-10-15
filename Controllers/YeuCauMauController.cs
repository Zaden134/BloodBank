using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class YeuCauMauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YeuCauMau (Hiển thị danh sách yêu cầu)
        public ActionResult Index()
        {
            // Dùng .Include() để lấy thông tin của NganHangMau liên quan
            var yeuCauMaus = db.YeuCauMaus.Include(y => y.NganHangMau);
            return View(yeuCauMaus.ToList());
        }

        // GET: YeuCauMau/Details/5 (Xem chi tiết)
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCauMau yeuCauMau = db.YeuCauMaus.Find(id);
            if (yeuCauMau == null)
            {
                return HttpNotFound();
            }
            return View(yeuCauMau);
        }

        // GET: YeuCauMau/Create (Hiển thị form tạo mới)
        public ActionResult Create()
        {
            // Tạo một SelectList chứa danh sách các ngân hàng máu để hiển thị trong dropdown
            ViewBag.IDMau = new SelectList(db.NganHangMaus, "IDMau", "DiaDiem");
            return View();
        }

        // POST: YeuCauMau/Create (Lưu dữ liệu)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDYeuCau,IDBenhNhan,LoaiMau,LuongMauYeuCau,NgayYC,TrangThai,IDMau")] YeuCauMau yeuCauMau)
        {
            if (ModelState.IsValid)
            {
                db.YeuCauMaus.Add(yeuCauMau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMau = new SelectList(db.NganHangMaus, "IDMau", "DiaDiem", yeuCauMau.IDMau);
            return View(yeuCauMau);
        }

        // GET: YeuCauMau/Edit/5 (Hiển thị form sửa)
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCauMau yeuCauMau = db.YeuCauMaus.Find(id);
            if (yeuCauMau == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMau = new SelectList(db.NganHangMaus, "IDMau", "DiaDiem", yeuCauMau.IDMau);
            return View(yeuCauMau);
        }

        // POST: YeuCauMau/Edit/5 (Lưu thay đổi)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDYeuCau,IDBenhNhan,LoaiMau,LuongMauYeuCau,NgayYC,TrangThai,IDMau")] YeuCauMau yeuCauMau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yeuCauMau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMau = new SelectList(db.NganHangMaus, "IDMau", "DiaDiem", yeuCauMau.IDMau);
            return View(yeuCauMau);
        }

        // GET: YeuCauMau/Delete/5 (Hiển thị form xác nhận xóa)
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCauMau yeuCauMau = db.YeuCauMaus.Find(id);
            if (yeuCauMau == null)
            {
                return HttpNotFound();
            }
            return View(yeuCauMau);
        }

        // POST: YeuCauMau/Delete/5 (Thực hiện xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            YeuCauMau yeuCauMau = db.YeuCauMaus.Find(id);
            db.YeuCauMaus.Remove(yeuCauMau);
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