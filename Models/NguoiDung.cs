using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    public class NguoiDung
    {
        [Key]
        public string IDNguoiDung { get; set; } = Guid.NewGuid().ToString(); // ✅ Tự sinh ID khi thêm mới

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100)]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [StringLength(255)]
        public string Password { get; set; } // ✅ Sẽ lưu password đã mã hoá (hash)

        [Required(ErrorMessage = "Vai trò không được để trống")]
        public string Role { get; set; } // BỆNH VIỆN, NGƯỜI HIẾN, NV NGÂN HÀNG MÁU

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(150)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(20)]
        public string SDT { get; set; }

        // ✅ Ảnh đại diện mặc định
        [StringLength(255)]
        public string AnhDaiDien { get; set; } = "/Content/Images/default-avatar.png";

        // Navigation properties
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
        public virtual ICollection<HienMau> HienMaus { get; set; }
    }
}
