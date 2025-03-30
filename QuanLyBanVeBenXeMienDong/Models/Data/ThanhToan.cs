using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ThanhToan
    {
        [Key]
        [StringLength(10)]
        public string MaGiaoDich { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        public decimal SoTien { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        [Required]
        public DateTime NgayThanhToan { get; set; }

        // Navigation properties
        public KhachHang KhachHang { get; set; }
        public NhaXe NhaXe { get; set; }
        public VeXe VeXe { get; set; }
    }
}
