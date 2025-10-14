
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class YeuCauMau
    {
        public string IDYeuCau { get; set; }
        public string IDBenhNhan { get; set; }
        public string LoaiMau { get; set; }
        public int LuongMauYeuCau { get; set; }
        public DateTime NgayYC { get; set; }
        public string TrangThai { get; set; } // Chờ, Đã phê duyệt, Đã từ chối

        // Quan hệ
        public string IDMau { get; set; }
        public virtual NganHangMau NganHangMau { get; set; }

        // Phương thức
        public void TaoYeuCau() { /* Tạo yêu cầu máu */ }
        public void KiemTraTrangThai() { /* Kiểm tra trạng thái yêu cầu */ }
    }
}