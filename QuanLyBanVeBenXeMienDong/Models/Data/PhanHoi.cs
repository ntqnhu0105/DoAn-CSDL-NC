using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class PhanHoi
    {
        [Key]
        [StringLength(10)]
        public string MaPhanHoi { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [StringLength(10)]
        public string? MaChuyen { get; set; }

        [Required]
        [StringLength(200)]
        public string NoiDung { get; set; }

        [Required]
        public DateTime NgayPhanHoi { get; set; }

        [StringLength(20)]
        public string? TrangThai { get; set; }

        // Navigation properties
        public KhachHang KhachHang { get; set; }
        public NhaXe NhaXe { get; set; }
        public ChuyenXe? ChuyenXe { get; set; }
    }
}
