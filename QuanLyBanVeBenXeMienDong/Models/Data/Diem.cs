using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class Diem
    {
        [Key]
        [StringLength(10)]
        public string MaDiem { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDiem { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTuyen { get; set; }

        [Required]
        [StringLength(20)]
        public string LoaiDiem { get; set; }

        [StringLength(50)]
        public string? ToaDoGPS { get; set; }

        // Navigation property
        public TuyenXe TuyenXe { get; set; }
    }
}
