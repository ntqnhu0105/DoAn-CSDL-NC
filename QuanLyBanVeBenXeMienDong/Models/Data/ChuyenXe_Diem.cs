using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ChuyenXe_Diem
    {
        [Key]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Key]
        [StringLength(10)]
        public string MaDiem { get; set; }

        [Required]
        public TimeSpan ThoiGianDuKien { get; set; }

        // Navigation properties
        public ChuyenXe ChuyenXe { get; set; }
        public Diem Diem { get; set; }
    }
}
