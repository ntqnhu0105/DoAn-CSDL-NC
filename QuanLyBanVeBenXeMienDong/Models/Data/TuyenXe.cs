using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class TuyenXe
    {
        [Key]
        [StringLength(10)]
        public string MaTuyen { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDi { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDen { get; set; }

        [Required]
        public decimal KhoangCach { get; set; }

        [Required]
        public TimeSpan ThoiGianDuKien { get; set; }

        [StringLength(200)]
        public string? MoTa { get; set; }

        public decimal? GiaThamKhao { get; set; }
    }
}
