using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class Xe
    {
        [Key]
        [StringLength(10)]
        public string MaXe { get; set; }
        public string BienSoXe { get; set; }
        public string MaLoai { get; set; }
        public string MaNhaXe { get; set; }
        public LoaiXe LoaiXe { get; set; }
        public NhaXe NhaXe { get; set; }
        public ICollection<SoGheSoGiuong> SoGheSoGiuongs { get; set; } // Add this line
    }
}
