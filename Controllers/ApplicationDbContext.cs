using System.Data.Entity;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            // Tự động cập nhật database theo model mới nhất khi chạy project
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, BloodBank.Migrations.Configuration>()
            );
        }

        // Các bảng
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NganHangMau> NganHangMaus { get; set; }
        public DbSet<YeuCauMau> YeuCauMaus { get; set; }
        public DbSet<HienMau> HienMaus { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<QuanTriVien> QuanTriViens { get; set; }

        // Factory
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
