using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class Xe
    {
        [Key]
        [StringLength(10)]
        public string MaXe { get; set; }

        [Required]
        [StringLength(12)]
        public string BienSoXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        // Navigation properties
        public LoaiXe LoaiXe { get; set; }
        public NhaXe NhaXe { get; set; }
    }
}
