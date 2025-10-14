using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class NganHangMau
    {
        [Key]
        public string IDMau { get; set; }
        public string DiaDiem { get; set; }

        public virtual ICollection<YeuCauMau> DSMau { get; set; }

        // Phương thức
        public void CapNhatDSMau() { /* Cập nhật danh sách máu */ }
        public void ChapThuanYeuCau() { /* Chấp thuận yêu cầu */ }
        public void TuChoiYeuCau() { /* Từ chối yêu cầu */ }
    }
}