namespace QuanLyBanVeBenXeMienDong.Models.Function
 {
   public class ChuyenXeEditDto
    {
        public string MaChuyen { get; set; }
        public string MaTuyen { get; set; }
        public string MaXe { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public TimeSpan GioKhoiHanh { get; set; }
        public decimal Gia { get; set; }
        public string TrangThai { get; set; }
    }
}