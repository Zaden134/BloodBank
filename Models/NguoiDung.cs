using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class NguoiDung
    {
        [Key]
        public string IDNguoiDung { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; } // BỆNH VIỆN, NGƯỜI HIẾN, NV NGÂN HÀNG MÁU

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        public string SDT { get; set; }

        public virtual ICollection<ThongBao> ThongBaos { get; set; }
        public virtual ICollection<HienMau> HienMaus { get; set; }
    }
}
