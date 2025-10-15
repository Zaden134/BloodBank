using System.Data.Entity; // Cần thêm để sử dụng .Include()
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class NganHangMauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NganHangMau (Hiển thị danh sách)
        public ActionResult Index()
        {
            var nganHangMaus = db.NganHangMaus.ToList();
            return View(nganHangMaus);
        }

        // GET: NganHangMau/Details/5 (Xem chi tiết)
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Dùng .Include để tải cả danh sách yêu cầu máu liên quan
            NganHangMau nganHangMau = db.NganHangMaus.Include(n => n.DSMau).SingleOrDefault(n => n.IDMau == id);
            if (nganHangMau == null)
            {
                return HttpNotFound();
            }
            return View(nganHangMau);
        }

        // GET: NganHangMau/Create (Hiển thị form tạo mới)
        public ActionResult Create()
        {
            return View();
        }

        // POST: NganHangMau/Create (Lưu dữ liệu)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMau,DiaDiem")] NganHangMau nganHangMau)
        {
            if (ModelState.IsValid)
            {
                db.NganHangMaus.Add(nganHangMau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nganHangMau);
        }

        // GET: NganHangMau/Edit/5 (Hiển thị form sửa)
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganHangMau nganHangMau = db.NganHangMaus.Find(id);
            if (nganHangMau == null)
            {
                return HttpNotFound();
            }
            return View(nganHangMau);
        }

        // POST: NganHangMau/Edit/5 (Lưu thay đổi)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMau,DiaDiem")] NganHangMau nganHangMau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganHangMau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nganHangMau);
        }

        // GET: NganHangMau/Delete/5 (Hiển thị form xác nhận xóa)
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganHangMau nganHangMau = db.NganHangMaus.Find(id);
            if (nganHangMau == null)
            {
                return HttpNotFound();
            }
            return View(nganHangMau);
        }

        // POST: NganHangMau/Delete/5 (Thực hiện xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NganHangMau nganHangMau = db.NganHangMaus.Find(id);
            db.NganHangMaus.Remove(nganHangMau);
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