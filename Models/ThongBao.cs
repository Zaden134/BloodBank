using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class ThongBao
    {
        [Key]
        public string IDThongBao { get; set; }
        public string TinNhan { get; set; }
        public string IDNguoiNhanTT { get; set; }
        public string ThongBaoLoaiMau { get; set; }

        // Quan hệ
        public virtual NguoiDung NguoiDung { get; set; }

        // Phương thức
        public void GuiThongBao() { /* Gửi thông báo */ }
        public void KiemTraThongBao() { /* Kiểm tra thông báo */ }
    }
}