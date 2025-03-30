using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class NhaXe
    {
        [Key]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhaXe { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }
    }
}
