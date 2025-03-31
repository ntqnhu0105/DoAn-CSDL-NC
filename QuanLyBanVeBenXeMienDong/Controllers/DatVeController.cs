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

            var gheList = await _context.SoGheSoGiuongs
                .Where(sg => sg.MaChuyen == maChuyen)
                .ToListAsync();

            // Chia ghế theo tầng
            ViewBag.GheTangDuoi = gheList.Where(g => g.Tang == 1).OrderBy(g => g.MaSoGhe).ToList();
            ViewBag.GheTangTren = gheList.Where(g => g.Tang == 2).OrderBy(g => g.MaSoGhe).ToList();

            // Lấy số điện thoại của người dùng
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                ViewBag.Sdt = user?.PhoneNumber ?? "";
            }
            else
            {
                ViewBag.Sdt = "";
            }

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
                MaSoGhe = string.Join(",", maSoGhe),
                MaXe = maXe,
                NgayDatVe = DateTime.Now,
                TrangThai = "Đã đặt",
                SoLuongVe = soLuongVe
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
                .ThenInclude(x => x.LoaiXe)
                .Include(v => v.KhachHang)
                .FirstOrDefaultAsync(v => v.MaVeXe == maVeXe);

            if (veXe == null)
            {
                return NotFound("Vé không tồn tại.");
            }

            if (veXe.MaKh != user.MaKh)
            {
                return Forbid("Bạn không có quyền xem thông tin vé này.");
            }

            return View(veXe);
        }
        [Authorize]
        public async Task<IActionResult> LichSuDatVe()
        {
            var user = await _userManager.GetUserAsync(User);
            var maKh = user.MaKh;

            if (string.IsNullOrEmpty(maKh))
            {
                return NotFound("Bạn chưa có mã khách hàng. Vui lòng đặt vé trước để xem lịch sử.");
            }

            var danhSachVe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .ThenInclude(c => c.TuyenXe)
                .Include(v => v.ChuyenXe.Xe)
                .ThenInclude(x => x.LoaiXe)
                .Include(v => v.KhachHang)
                .Where(v => v.MaKh == maKh)
                .OrderByDescending(v => v.NgayDatVe) // Sắp xếp theo ngày đặt vé mới nhất
                .ToListAsync();

            return View(danhSachVe);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> HuyVe(string maVeXe)
        {
            var user = await _userManager.GetUserAsync(User);
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .FirstOrDefaultAsync(v => v.MaVeXe == maVeXe);

            if (veXe == null)
            {
                return NotFound("Vé không tồn tại.");
            }

            if (veXe.MaKh != user.MaKh)
            {
                return Forbid("Bạn không có quyền hủy vé này.");
            }

            if (veXe.TrangThai != "Đã đặt" && veXe.TrangThai != "Đã thanh toán")
            {
                return BadRequest("Chỉ có thể hủy vé ở trạng thái 'Đã đặt' hoặc 'Đã thanh toán'.");
            }

            veXe.TrangThai = "Đã hủy";
            _context.VeXes.Update(veXe);

            var maSoGheList = veXe.MaSoGhe.Split(',');
            var gheList = await _context.SoGheSoGiuongs
                .Where(sg => sg.MaChuyen == veXe.MaChuyen && sg.MaXe == veXe.MaXe && maSoGheList.Contains(sg.MaSoGhe))
                .ToListAsync();

            foreach (var ghe in gheList)
            {
                ghe.TrangThai = "Trống";
                _context.SoGheSoGiuongs.Update(ghe);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("LichSuDatVe");
        }
    }
}