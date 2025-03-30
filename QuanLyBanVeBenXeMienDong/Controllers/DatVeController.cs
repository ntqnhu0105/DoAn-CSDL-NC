using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;
using QuanLyBanVeBenXeMienDong.Models.System;

namespace QuanLyBanVeBenXeMienDong.Controllers
{
    public class DatVeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DatVeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Các action Book hiện có (giữ nguyên)

        [Authorize]
        public async Task<IActionResult> Book(string maChuyen)
        {
            var chuyenXe = await _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Include(c => c.Xe)
                .ThenInclude(x => x.LoaiXe)
                .FirstOrDefaultAsync(c => c.MaChuyen == maChuyen);

            if (chuyenXe == null || chuyenXe.TrangThai != "Chưa khởi hành")
            {
                return NotFound("Chuyến xe không tồn tại hoặc không khả dụng.");
            }

            var gheTrong = await _context.SoGheSoGiuongs
                .Where(sg => sg.MaChuyen == maChuyen && sg.TrangThai == "Trống")
                .ToListAsync();

            ViewBag.GheTrong = gheTrong;
            return View(chuyenXe);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Book(string maChuyen, string maXe, string sdt, int soLuongVe, string[] maSoGhe)
        {
            var chuyenXe = await _context.ChuyenXes.FindAsync(maChuyen);
            if (chuyenXe == null || chuyenXe.TrangThai != "Chưa khởi hành")
            {
                return BadRequest("Chuyến xe không khả dụng.");
            }

            // Kiểm tra số lượng ghế trống
            var gheTrong = await _context.SoGheSoGiuongs
                .Where(sg => sg.MaChuyen == maChuyen && sg.MaXe == maXe && sg.TrangThai == "Trống")
                .ToListAsync();

            if (gheTrong.Count < soLuongVe)
            {
                return BadRequest("Không đủ ghế trống để đặt số lượng vé yêu cầu.");
            }

            if (maSoGhe == null || maSoGhe.Length != soLuongVe)
            {
                return BadRequest("Số lượng ghế được chọn không khớp với số lượng vé.");
            }

            // Kiểm tra các ghế được chọn có hợp lệ không
            var gheDuocChon = gheTrong.Where(g => maSoGhe.Contains(g.MaSoGhe)).ToList();
            if (gheDuocChon.Count != soLuongVe)
            {
                return BadRequest("Một hoặc nhiều ghế đã chọn không hợp lệ hoặc đã được đặt.");
            }

            var user = await _userManager.GetUserAsync(User);
            string maKh = user.MaKh;

            if (string.IsNullOrEmpty(maKh))
            {
                maKh = "KH" + Guid.NewGuid().ToString().Substring(0, 8);
                if (string.IsNullOrEmpty(sdt))
                {
                    return BadRequest("Vui lòng cung cấp số điện thoại.");
                }
                var khachHang = new KhachHang
                {
                    MaKh = maKh,
                    HovaTen = user.UserName,
                    Email = user.Email,
                    SDT = sdt
                };
                _context.KhachHangs.Add(khachHang);
                user.MaKh = maKh;
                await _userManager.UpdateAsync(user);
            }

            // Tạo bản ghi VeXe
            var veXe = new VeXe
            {
                MaVeXe = Guid.NewGuid().ToString().Substring(0, 10),
                MaChuyen = maChuyen,
                MaKh = maKh,
                MANV = "NV000",
                MaSoGhe = string.Join(",", maSoGhe), // Lưu danh sách ghế dưới dạng chuỗi
                MaXe = maXe,
                NgayDatVe = DateTime.Now,
                TrangThai = "Đã đặt",
                SoLuongVe = soLuongVe // Gán số lượng vé từ form
            };

            // Cập nhật trạng thái các ghế được chọn
            foreach (var ghe in gheDuocChon)
            {
                ghe.TrangThai = "Đã đặt";
                _context.SoGheSoGiuongs.Update(ghe);
            }

            _context.VeXes.Add(veXe);
            await _context.SaveChangesAsync();

            return RedirectToAction("ThanhToan", new { maVeXe = veXe.MaVeXe });
        }
        [Authorize]
        public async Task<IActionResult> ThanhToan(string maVeXe)
        {
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .ThenInclude(c => c.TuyenXe)
                .Include(v => v.ChuyenXe.Xe)
                .FirstOrDefaultAsync(v => v.MaVeXe == maVeXe);

            if (veXe == null || veXe.TrangThai != "Đã đặt")
            {
                return NotFound("Vé không tồn tại hoặc đã được thanh toán.");
            }

            return View(veXe);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ThanhToan(string maVeXe, string phuongThucThanhToan)
        {
            var veXe = await _context.VeXes.FindAsync(maVeXe);
            if (veXe == null || veXe.TrangThai != "Đã đặt")
            {
                return BadRequest("Vé không khả dụng để thanh toán.");
            }

            // Giả lập xử lý thanh toán (thay bằng logic thực tế nếu có)
            veXe.TrangThai = "Đã thanh toán";
            _context.VeXes.Update(veXe);
            await _context.SaveChangesAsync();

            return RedirectToAction("XacNhan", new { maVeXe = veXe.MaVeXe });
        }

        [Authorize]
        public async Task<IActionResult> XacNhan(string maVeXe)
        {
            var user = await _userManager.GetUserAsync(User);
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .ThenInclude(c => c.TuyenXe)
                .Include(v => v.ChuyenXe.Xe)
                .ThenInclude(x => x.LoaiXe) // Thêm ThenInclude để tải LoaiXe
                .Include(v => v.KhachHang)
                .FirstOrDefaultAsync(v => v.MaVeXe == maVeXe);

            if (veXe == null || veXe.TrangThai != "Đã thanh toán")
            {
                return NotFound("Vé không tồn tại hoặc chưa được thanh toán.");
            }

            if (veXe.MaKh != user.MaKh)
            {
                return Forbid("Bạn không có quyền xem thông tin vé này.");
            }

            // Kiểm tra các navigation properties
            if (veXe.ChuyenXe == null || veXe.ChuyenXe.TuyenXe == null || veXe.ChuyenXe.Xe == null || veXe.ChuyenXe.Xe.LoaiXe == null || veXe.KhachHang == null)
            {
                // Ghi log để kiểm tra (hoặc dùng Console.WriteLine nếu đang debug)
                Console.WriteLine($"Dữ liệu thiếu: ChuyenXe: {veXe.ChuyenXe != null}, TuyenXe: {veXe.ChuyenXe?.TuyenXe != null}, Xe: {veXe.ChuyenXe?.Xe != null}, LoaiXe: {veXe.ChuyenXe?.Xe?.LoaiXe != null}, KhachHang: {veXe.KhachHang != null}");
                return BadRequest("Dữ liệu vé không đầy đủ.");
            }

            return View(veXe);
        }
    }
}