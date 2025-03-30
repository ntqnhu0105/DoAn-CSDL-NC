using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ChuyenXe
    {
        [Key]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTuyen { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; }

        [Required]
        public DateTime NgayKhoiHanh { get; set; }

        [Required]
        public TimeSpan GioKhoiHanh { get; set; }

        [Required]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        // Navigation properties
        public TuyenXe TuyenXe { get; set; }
        public Xe Xe { get; set; }
    }
}
