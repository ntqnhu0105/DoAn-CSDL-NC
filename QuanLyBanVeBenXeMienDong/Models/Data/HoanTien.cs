using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class HoanTien
    {
        [Key]
        [StringLength(10)]
        public string MaHoanTien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        public decimal SoTienHoan { get; set; }

        [Required]
        [StringLength(200)]
        public string LyDo { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        [Required]
        public DateTime NgayYeuCau { get; set; }

        // Navigation properties
        public VeXe VeXe { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
