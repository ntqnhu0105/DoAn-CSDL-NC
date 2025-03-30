using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class VeXe_SoGhe
    {
        [Key]
        public int Id { get; set; } // Khóa chính

        [Required]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSoGhe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        // Navigation properties
        public VeXe VeXe { get; set; }
        public SoGheSoGiuong SoGheSoGiuong { get; set; }
    }
}