using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NganHangMau> NganHangMaus { get; set; }
        public DbSet<YeuCauMau> YeuCauMaus { get; set; }
        public DbSet<HienMau> HienMaus { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<QuanTriVien> QuanTriViens { get; set; }
    }
}