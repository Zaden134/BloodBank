
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class QuanTriVien
    {
        public string IDQuanTriVien { get; set; }
        public string TenQTV { get; set; }
        public string Email { get; set; }

        // Quan hệ
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }

        // Phương thức
        public void QuanLyNguoiDung() { /* Quản lý người dùng */ }
        public void TaoBaoCao() { /* Tạo báo cáo thống kê */ }
    }
}