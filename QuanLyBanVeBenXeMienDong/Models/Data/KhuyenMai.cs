using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class KhuyenMai
    {
        [Key]
        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhuyenMai { get; set; }

        [StringLength(200)]
        public string? MoTa { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal MucGiamGia { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }

        [Required]
        public DateTime NgayKetThuc { get; set; }
    }
}
