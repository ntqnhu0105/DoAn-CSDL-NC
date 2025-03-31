using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ChuyenXe
    {
        [Key] // Định nghĩa MaChuyen là khóa chính
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
        public string GioKhoiHanh { get; set; }

        [Required]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        // Navigation properties
        public TuyenXe TuyenXe { get; set; }
        public Xe Xe { get; set; }
        public ICollection<VeXe> VeXes { get; set; }
        public ICollection<SoGheSoGiuong> SoGheSoGiuongs { get; set; }
    }
}