using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;

namespace QuanLyBanVeBenXeMienDong.Models.System
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXe> NhaXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<TaiXe> TaiXes { get; set; }
        public DbSet<TuyenXe> TuyenXes { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<ChuyenXe> ChuyenXes { get; set; }
        public DbSet<ChuyenXe_Diem> ChuyenXe_Diems { get; set; }
        public DbSet<SoGheSoGiuong> SoGheSoGiuongs { get; set; }
        public DbSet<PhanCong> PhanCongs { get; set; }
        public DbSet<PhanHoi> PhanHois { get; set; }
        public DbSet<QuayBanVe> QuayBanVes { get; set; }
        public DbSet<VeXe> VeXes { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<HoanTien> HoanTiens { get; set; }
        public DbSet<VeXe_SoGhe> VeXe_SoGhes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cấu hình khóa chính composite
            modelBuilder.Entity<ChuyenXe_Diem>()
        .HasKey(cd => new { cd.MaChuyen, cd.MaDiem });

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasKey(sg => new { sg.MaSoGhe, sg.MaXe, sg.MaChuyen });

            // Cấu hình các mối quan hệ
            modelBuilder.Entity<Xe>()
                .HasOne(x => x.LoaiXe)
                .WithMany()
                .HasForeignKey(x => x.MaLoai);

            modelBuilder.Entity<Xe>()
                .HasOne(x => x.NhaXe)
                .WithMany()
                .HasForeignKey(x => x.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NhanVien>()
                .HasOne(n => n.NhaXe)
                .WithMany()
                .HasForeignKey(n => n.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Diem>()
                .HasOne(d => d.TuyenXe)
                .WithMany()
                .HasForeignKey(d => d.MaTuyen);

            modelBuilder.Entity<ChuyenXe>()
                .HasOne(c => c.TuyenXe)
                .WithMany()
                .HasForeignKey(c => c.MaTuyen);

            modelBuilder.Entity<ChuyenXe>()
                .HasOne(c => c.Xe)
                .WithMany()
                .HasForeignKey(c => c.MaXe);

            modelBuilder.Entity<ChuyenXe_Diem>()
                .HasOne(cd => cd.ChuyenXe)
                .WithMany()
                .HasForeignKey(cd => cd.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChuyenXe_Diem>()
                .HasOne(cd => cd.Diem)
                .WithMany()
                .HasForeignKey(cd => cd.MaDiem);

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.Xe)
                .WithMany()
                .HasForeignKey(sg => sg.MaXe);

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.ChuyenXe)
                .WithMany()
                .HasForeignKey(sg => sg.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PhanCong>()
                .HasOne(pc => pc.TaiXe)
                .WithMany()
                .HasForeignKey(pc => pc.MaTaiXe);

            modelBuilder.Entity<PhanCong>()
                .HasOne(pc => pc.ChuyenXe)
                .WithMany()
                .HasForeignKey(pc => pc.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PhanHoi>()
                .HasOne(ph => ph.KhachHang)
                .WithMany()
                .HasForeignKey(ph => ph.MaKh);

            modelBuilder.Entity<PhanHoi>()
                .HasOne(ph => ph.NhaXe)
                .WithMany()
                .HasForeignKey(ph => ph.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PhanHoi>()
                .HasOne(ph => ph.ChuyenXe)
                .WithMany()
                .HasForeignKey(ph => ph.MaChuyen)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<QuayBanVe>()
                .HasOne(q => q.NhaXe)
                .WithMany()
                .HasForeignKey(q => q.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QuayBanVe>()
                .HasOne(q => q.NhanVien)
                .WithMany()
                .HasForeignKey(q => q.MANV)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.ChuyenXe)
                .WithMany()
                .HasForeignKey(v => v.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.KhachHang)
                .WithMany()
                .HasForeignKey(v => v.MaKh);

            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.NhanVien)
                .WithMany()
                .HasForeignKey(v => v.MANV);

            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.KhuyenMai)
                .WithMany()
                .HasForeignKey(v => v.MaKhuyenMai)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<VeXe_SoGhe>()
                .HasOne(vs => vs.VeXe)
                .WithMany(v => v.VeXe_SoGhes)
                .HasForeignKey(vs => vs.MaVeXe);

            modelBuilder.Entity<VeXe_SoGhe>()
                .HasOne(vs => vs.SoGheSoGiuong)
                .WithMany()
                .HasForeignKey(vs => new { vs.MaSoGhe, vs.MaXe, vs.MaChuyen });
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.KhachHang)
                .WithMany()
                .HasForeignKey(t => t.MaKh);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.NhaXe)
                .WithMany()
                .HasForeignKey(t => t.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.VeXe)
                .WithMany()
                .HasForeignKey(t => t.MaVeXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HoanTien>()
                .HasOne(h => h.VeXe)
                .WithMany()
                .HasForeignKey(h => h.MaVeXe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HoanTien>()
                .HasOne(h => h.KhachHang)
                .WithMany()
                .HasForeignKey(h => h.MaKh);
            modelBuilder.Entity<SoGheSoGiuong>()
            .HasOne(s => s.Xe)
            .WithMany(x => x.SoGheSoGiuongs) // Thêm ICollection<SoGheSoGiuong> SoGheSoGiuongs vào model Xe nếu cần
            .HasForeignKey(s => s.MaXe);
            modelBuilder.Entity<NhanVien>().HasData( 
                new NhanVien
                {
                    MaNhaXe = "NX001",
                    MANV = "NV000",
                    HovaTen = "Nguyễn Thanh Thúy",
                    SDT = "0123456789",
                    CCCD = "056304007372",
                    ChucVu = "Nhân viên",
                    Email = "thuy@gmail.com"
                }
            );
            modelBuilder.Entity<LoaiXe>().HasData(
                new LoaiXe { MaLoai = "LX001", TenLoai = "Xe giường nằm", SoLuongGhe = 40, MoTa = "Xe cao cấp, có điều hòa" },
                new LoaiXe { MaLoai = "LX002", TenLoai = "Xe ghế ngồi", SoLuongGhe = 45, MoTa = "Xe phổ thông" },
                new LoaiXe { MaLoai = "LX003", TenLoai = "Xe limousine", SoLuongGhe = 20, MoTa = "Xe sang trọng, ít ghế" },
                new LoaiXe { MaLoai = "LX004", TenLoai = "Xe VIP", SoLuongGhe = 30, MoTa = "Xe cao cấp, ghế rộng" }
            );

            // Dữ liệu mẫu cho NhaXe
            modelBuilder.Entity<NhaXe>().HasData(
                new NhaXe { MaNhaXe = "NX001", TenNhaXe = "Nhà xe Miền Đông", DiaChi = "292 Đinh Bộ Lĩnh, TP.HCM", Email = "mien_dong@gmail.com", SDT = "0901234567" },
                new NhaXe { MaNhaXe = "NX002", TenNhaXe = "Nhà xe Phương Trang", DiaChi = "80 Trần Hưng Đạo, TP.HCM", Email = "phuongtrang@gmail.com", SDT = "0909876543" },
                new NhaXe { MaNhaXe = "NX003", TenNhaXe = "Nhà xe Thành Bưởi", DiaChi = "266 Lê Hồng Phong, TP.HCM", Email = "thanhbuoi@gmail.com", SDT = "0912345678" },
                new NhaXe { MaNhaXe = "NX004", TenNhaXe = "Nhà xe Hoàng Long", DiaChi = "5 Phạm Ngũ Lão, Hà Nội", Email = "hoanglong@gmail.com", SDT = "0987654321" },
                new NhaXe { MaNhaXe = "NX005", TenNhaXe = "Nhà xe Mai Linh", DiaChi = "102 Nguyễn Văn Trỗi, TP.HCM", Email = "mailinh@gmail.com", SDT = "0918889999" },
                new NhaXe { MaNhaXe = "NX006", TenNhaXe = "Nhà xe Futa Bus Lines", DiaChi = "50 Lê Văn Lương, TP.HCM", Email = "futa@gmail.com", SDT = "0923456789" },
                new NhaXe { MaNhaXe = "NX007", TenNhaXe = "Nhà xe Thành Công", DiaChi = "12 Võ Thị Sáu, TP.HCM", Email = "thanhcong@gmail.com", SDT = "0904455667" },
                new NhaXe { MaNhaXe = "NX008", TenNhaXe = "Nhà xe Bình Minh", DiaChi = "22 Nguyễn Huệ, TP.HCM", Email = "binhminh@gmail.com", SDT = "0966668888" }
            );

            // Dữ liệu mẫu cho Xe
            modelBuilder.Entity<Xe>().HasData(
                new Xe { MaXe = "XE001", BienSoXe = "51B-12345", MaLoai = "LX001", MaNhaXe = "NX001" },
                new Xe { MaXe = "XE002", BienSoXe = "29A-54321", MaLoai = "LX002", MaNhaXe = "NX002" },
                new Xe { MaXe = "XE003", BienSoXe = "51B-67890", MaLoai = "LX003", MaNhaXe = "NX003" },
                new Xe { MaXe = "XE004", BienSoXe = "30A-11111", MaLoai = "LX004", MaNhaXe = "NX004" },
                new Xe { MaXe = "XE005", BienSoXe = "51B-22222", MaLoai = "LX001", MaNhaXe = "NX001" },
                new Xe { MaXe = "XE006", BienSoXe = "29A-33333", MaLoai = "LX002", MaNhaXe = "NX002" },
                new Xe { MaXe = "XE007", BienSoXe = "51B-77777", MaLoai = "LX003", MaNhaXe = "NX005" },
                new Xe { MaXe = "XE008", BienSoXe = "29A-88888", MaLoai = "LX002", MaNhaXe = "NX006" },
                new Xe { MaXe = "XE009", BienSoXe = "51B-99999", MaLoai = "LX004", MaNhaXe = "NX007" },
                new Xe { MaXe = "XE010", BienSoXe = "50B-12345", MaLoai = "LX001", MaNhaXe = "NX008" }
            );

            // Dữ liệu mẫu cho TuyenXe
            modelBuilder.Entity<TuyenXe>().HasData(
                new TuyenXe { MaTuyen = "TX001", DiemDi = "TP. Hồ Chí Minh", DiemDen = "Đà Lạt", KhoangCach = 300m, ThoiGianDuKien = TimeSpan.FromHours(6), MoTa = "Tuyến đường cao tốc, có cảnh đẹp", GiaThamKhao = 250000m },
                new TuyenXe { MaTuyen = "TX002", DiemDi = "Hà Nội", DiemDen = "Hải Phòng", KhoangCach = 120m, ThoiGianDuKien = TimeSpan.FromHours(2), MoTa = "Tuyến ngắn, thuận tiện", GiaThamKhao = 100000m },
                new TuyenXe { MaTuyen = "TX003", DiemDi = "Đà Nẵng", DiemDen = "Huế", KhoangCach = 100m, ThoiGianDuKien = TimeSpan.FromHours(2.5), MoTa = "Tuyến ven biển, phong cảnh đẹp", GiaThamKhao = 120000m },
                new TuyenXe { MaTuyen = "TX004", DiemDi = "TP. Hồ Chí Minh", DiemDen = "Nha Trang", KhoangCach = 450m, ThoiGianDuKien = TimeSpan.FromHours(8), MoTa = "Tuyến dài, có nghỉ trạm", GiaThamKhao = 300000m },
                new TuyenXe { MaTuyen = "TX005", DiemDi = "Hà Nội", DiemDen = "Sa Pa", KhoangCach = 320m, ThoiGianDuKien = TimeSpan.FromHours(6.5), MoTa = "Tuyến miền núi, cảnh đẹp", GiaThamKhao = 280000m },
                new TuyenXe { MaTuyen = "TX006", DiemDi = "Cần Thơ", DiemDen = "TP. Hồ Chí Minh", KhoangCach = 170m, ThoiGianDuKien = TimeSpan.FromHours(3.5), MoTa = "Tuyến đồng bằng, nhanh chóng", GiaThamKhao = 150000m },
                new TuyenXe { MaTuyen = "TX007", DiemDi = "TP. Hồ Chí Minh", DiemDen = "Cà Mau", KhoangCach = 350m, ThoiGianDuKien = TimeSpan.FromHours(7), MoTa = "Tuyến đường về miền Tây", GiaThamKhao = 280000m },
                new TuyenXe { MaTuyen = "TX008", DiemDi = "Hà Nội", DiemDen = "Thanh Hóa", KhoangCach = 160m, ThoiGianDuKien = TimeSpan.FromHours(3.5), MoTa = "Tuyến phía Bắc tiện lợi", GiaThamKhao = 150000m },
                new TuyenXe { MaTuyen = "TX009", DiemDi = "Đà Nẵng", DiemDen = "Quảng Ngãi", KhoangCach = 120m, ThoiGianDuKien = TimeSpan.FromHours(2.5), MoTa = "Tuyến miền Trung nhanh chóng", GiaThamKhao = 130000m }
            );

            modelBuilder.Entity<ChuyenXe>().HasData(
                new ChuyenXe { MaChuyen = "CX001", MaTuyen = "TX001", MaXe = "XE001", NgayKhoiHanh = DateTime.Now.AddDays(1), GioKhoiHanh = "07:00", Gia = 250000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX002", MaTuyen = "TX002", MaXe = "XE002", NgayKhoiHanh = DateTime.Now.AddDays(1), GioKhoiHanh = "09:00", Gia = 100000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX003", MaTuyen = "TX003", MaXe = "XE003", NgayKhoiHanh = DateTime.Now.AddDays(2), GioKhoiHanh = "14:00", Gia = 120000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX004", MaTuyen = "TX004", MaXe = "XE004", NgayKhoiHanh = DateTime.Now.AddDays(1), GioKhoiHanh = "08:00", Gia = 300000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX005", MaTuyen = "TX005", MaXe = "XE005", NgayKhoiHanh = DateTime.Now.AddDays(2), GioKhoiHanh = "20:00", Gia = 280000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX006", MaTuyen = "TX006", MaXe = "XE006", NgayKhoiHanh = DateTime.Now.AddDays(1), GioKhoiHanh = "13:00", Gia = 150000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX007", MaTuyen = "TX002", MaXe = "XE002", NgayKhoiHanh = DateTime.Now.AddDays(2), GioKhoiHanh = "15:00", Gia = 100000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX008", MaTuyen = "TX001", MaXe = "XE001", NgayKhoiHanh = DateTime.Now.AddDays(3), GioKhoiHanh = "10:00", Gia = 250000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX009", MaTuyen = "TX004", MaXe = "XE004", NgayKhoiHanh = DateTime.Now.AddDays(2), GioKhoiHanh = "17:00", Gia = 300000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX010", MaTuyen = "TX007", MaXe = "XE007", NgayKhoiHanh = DateTime.Now.AddDays(1), GioKhoiHanh = "05:00", Gia = 280000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX011", MaTuyen = "TX008", MaXe = "XE008", NgayKhoiHanh = DateTime.Now.AddDays(2), GioKhoiHanh = "14:00", Gia = 150000m, TrangThai = "Chưa khởi hành" },
                new ChuyenXe { MaChuyen = "CX012", MaTuyen = "TX009", MaXe = "XE009", NgayKhoiHanh = DateTime.Now.AddDays(3), GioKhoiHanh = "08:00", Gia = 130000m, TrangThai = "Chưa khởi hành" }
            );

            // Dữ liệu mẫu cho SoGheSoGiuong
            modelBuilder.Entity<SoGheSoGiuong>().HasData(
                new SoGheSoGiuong { MaSoGhe = "A01", MaXe = "XE001", MaChuyen = "CX001", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "A02", MaXe = "XE001", MaChuyen = "CX001", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "A03", MaXe = "XE001", MaChuyen = "CX001", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "B01", MaXe = "XE002", MaChuyen = "CX002", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "B02", MaXe = "XE002", MaChuyen = "CX002", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "B03", MaXe = "XE002", MaChuyen = "CX002", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "C01", MaXe = "XE003", MaChuyen = "CX003", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "C02", MaXe = "XE003", MaChuyen = "CX003", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "D01", MaXe = "XE004", MaChuyen = "CX004", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "D02", MaXe = "XE004", MaChuyen = "CX004", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "E01", MaXe = "XE005", MaChuyen = "CX005", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "E02", MaXe = "XE005", MaChuyen = "CX005", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "F01", MaXe = "XE006", MaChuyen = "CX006", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "F02", MaXe = "XE006", MaChuyen = "CX006", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "B04", MaXe = "XE002", MaChuyen = "CX007", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "A04", MaXe = "XE001", MaChuyen = "CX008", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "D03", MaXe = "XE004", MaChuyen = "CX009", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "G01", MaXe = "XE007", MaChuyen = "CX010", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "G02", MaXe = "XE007", MaChuyen = "CX010", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "H01", MaXe = "XE008", MaChuyen = "CX011", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "H02", MaXe = "XE008", MaChuyen = "CX011", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "I01", MaXe = "XE009", MaChuyen = "CX012", TrangThai = "Trống" },
                new SoGheSoGiuong { MaSoGhe = "I02", MaXe = "XE009", MaChuyen = "CX012", TrangThai = "Trống" }
            );
        }
    }
}
