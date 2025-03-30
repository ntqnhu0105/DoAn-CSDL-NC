using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class PhanCong
    {
        [Key]
        [StringLength(10)]
        public string MaPhanCong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTaiXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        public DateTime NgayPhanCong { get; set; }

        [StringLength(200)]
        public string? GhiChu { get; set; }

        // Navigation properties
        public TaiXe TaiXe { get; set; }
        public ChuyenXe ChuyenXe { get; set; }
    }
}
