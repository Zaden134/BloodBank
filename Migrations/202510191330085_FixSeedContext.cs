namespace BloodBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSeedContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.HienMaus",
                c => new
                    {
                        IDMaHienMau = c.String(nullable: false, maxLength: 128),
                        IDNguoiHien = c.String(),
                        LoaiMau = c.String(),
                        NgayHienMau = c.DateTime(nullable: false),
                        LuongMauHien = c.Int(nullable: false),
                        NguoiDung_IDNguoiDung = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDMaHienMau)
                .ForeignKey("dbo.NguoiDungs", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.NguoiDungs",
                c => new
                    {
                        IDNguoiDung = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 255),
                        Role = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 150),
                        SDT = c.String(maxLength: 20),
                        AnhDaiDien = c.String(maxLength: 255),
                        QuanTriVien_IDQuanTriVien = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDNguoiDung)
                .ForeignKey("dbo.QuanTriViens", t => t.QuanTriVien_IDQuanTriVien)
                .Index(t => t.QuanTriVien_IDQuanTriVien);
            
            CreateTable(
                "dbo.ThongBaos",
                c => new
                    {
                        IDThongBao = c.String(nullable: false, maxLength: 128),
                        TinNhan = c.String(),
                        IDNguoiNhanTT = c.String(),
                        ThongBaoLoaiMau = c.String(),
                        NguoiDung_IDNguoiDung = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDThongBao)
                .ForeignKey("dbo.NguoiDungs", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.NganHangMaus",
                c => new
                    {
                        IDMau = c.String(nullable: false, maxLength: 128),
                        DiaDiem = c.String(),
                    })
                .PrimaryKey(t => t.IDMau);
            
            CreateTable(
                "dbo.YeuCauMaus",
                c => new
                    {
                        IDYeuCau = c.String(nullable: false, maxLength: 128),
                        IDBenhNhan = c.String(),
                        LoaiMau = c.String(),
                        LuongMauYeuCau = c.Int(nullable: false),
                        NgayYC = c.DateTime(nullable: false),
                        TrangThai = c.String(),
                        IDMau = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDYeuCau)
                .ForeignKey("dbo.NganHangMaus", t => t.IDMau)
                .Index(t => t.IDMau);
            
            CreateTable(
                "dbo.QuanTriViens",
                c => new
                    {
                        IDQuanTriVien = c.String(nullable: false, maxLength: 128),
                        TenQTV = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDQuanTriVien);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.NguoiDungs", "QuanTriVien_IDQuanTriVien", "dbo.QuanTriViens");
            DropForeignKey("dbo.YeuCauMaus", "IDMau", "dbo.NganHangMaus");
            DropForeignKey("dbo.ThongBaos", "NguoiDung_IDNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.HienMaus", "NguoiDung_IDNguoiDung", "dbo.NguoiDungs");
            DropIndex("dbo.YeuCauMaus", new[] { "IDMau" });
            DropIndex("dbo.ThongBaos", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.NguoiDungs", new[] { "QuanTriVien_IDQuanTriVien" });
            DropIndex("dbo.HienMaus", new[] { "NguoiDung_IDNguoiDung" });
            DropTable("dbo.QuanTriViens");
            DropTable("dbo.YeuCauMaus");
            DropTable("dbo.NganHangMaus");
            DropTable("dbo.ThongBaos");
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.HienMaus");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
