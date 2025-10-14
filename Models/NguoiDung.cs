using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class NguoiDung
    {
        public string IDNguoiDung { get; set; }
        public string Ten { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // BỆNH VIỆN, NGƯỜI HIẾN, NV NGÂN HÀNG MÁU
        public string Email { get; set; }
        public string SDT { get; set; }

        // Quan hệ
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
        public virtual ICollection<HienMau> HienMaus { get; set; }

        // Phương thức
        public void Login() { /* Xử lý đăng nhập */ }
        public void Register() { /* Xử lý đăng ký */ }
        public void UpdateProfile() { /* Cập nhật thông tin */ }
    }
}