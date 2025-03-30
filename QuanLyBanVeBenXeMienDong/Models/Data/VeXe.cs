using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class VeXe
    {
        [Key]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        public string MaKh { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSoGhe { get; set; } // Chuỗi chứa danh sách ghế

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; }

        [StringLength(10)]
        public string? MaKhuyenMai { get; set; }

        [Required]
        public DateTime NgayDatVe { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        [Required]
        public int SoLuongVe { get; set; }

        public ChuyenXe ChuyenXe { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
        public ICollection<VeXe_SoGhe> VeXe_SoGhes { get; set; }
        public KhuyenMai? KhuyenMai { get; set; }
    }
}