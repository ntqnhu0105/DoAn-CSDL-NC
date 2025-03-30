using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? DiaChi { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        // Navigation property
        public NhaXe NhaXe { get; set; }
    }
}
