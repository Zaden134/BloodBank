using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class HienMau
    {
        public string IDMaHienMau { get; set; }
        public string IDNguoiHien { get; set; }
        public string LoaiMau { get; set; }
        public DateTime NgayHienMau { get; set; }
        public int LuongMauHien { get; set; }

        // Quan hệ
        public virtual NguoiDung NguoiDung { get; set; }

        // Phương thức
        public void GhiNhanThiHienMau() { /* Ghi nhận khi người hiến máu */ }
        public void LichSuHienMau() { /* Lịch sử hiến máu */ }
    }
}