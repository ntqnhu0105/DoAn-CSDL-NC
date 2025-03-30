using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class SoGheSoGiuong
    {
        [Key]
        [StringLength(10)]
        public string MaSoGhe { get; set; }

        [Key]
        [StringLength(10)]
        public string MaXe { get; set; }

        [Key]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        [StringLength(10)]
        public string TrangThai { get; set; }

        // Navigation properties
        public Xe Xe { get; set; }
        public ChuyenXe ChuyenXe { get; set; }
    }
}
