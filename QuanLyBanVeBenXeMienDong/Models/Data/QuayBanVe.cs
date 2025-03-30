using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class QuayBanVe
    {
        [Key]
        [StringLength(10)]
        public string MaQuay { get; set; }

        [Required]
        [StringLength(50)]
        public string TenQuay { get; set; }

        [Required]
        [StringLength(100)]
        public string ViTri { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [StringLength(10)]
        public string? MANV { get; set; }

        // Navigation properties
        public NhaXe NhaXe { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
