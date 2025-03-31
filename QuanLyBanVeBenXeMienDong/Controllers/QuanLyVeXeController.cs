using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;
using QuanLyBanVeBenXeMienDong.Models.System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanVeBenXeMienDong.Controllers
{
    [Authorize(Roles = "NhanVien")] // Chỉ nhân viên có vai trò NhanVien truy cập
    public class QuanLyVeXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyVeXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Xem danh sách vé
        public async Task<IActionResult> Index(string maChuyen, DateTime? ngayDatVe, string trangThai)
        {
            var veXes = from v in _context.VeXes
                        .Include(v => v.ChuyenXe)
                        .Include(v => v.NhanVien)
                        .Include(v => v.KhachHang)
                        select v;

            if (!string.IsNullOrEmpty(maChuyen))
            {
                veXes = veXes.Where(v => v.MaChuyen == maChuyen);
            }
            if (ngayDatVe.HasValue)
            {
                veXes = veXes.Where(v => v.NgayDatVe.Date == ngayDatVe.Value.Date);
            }
            if (!string.IsNullOrEmpty(trangThai))
            {
                veXes = veXes.Where(v => v.TrangThai == trangThai);
            }

            return View(await veXes.ToListAsync());
        }

        // Thêm vé (GET)
        public IActionResult Create()
        {
            ViewBag.ChuyenXes = _context.ChuyenXes.Where(c => c.TrangThai == "Hoạt động").ToList(); // Chỉ hiển thị chuyến xe đang hoạt động
            ViewBag.SoGheSoGiuongs = _context.SoGheSoGiuongs.Where(s => s.TrangThai == "Còn trống").ToList();
            return View();
        }

        // Thêm vé (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeXe veXe)
        {
            if (ModelState.IsValid)
            {
                // Gán MANV từ nhân viên đăng nhập
                veXe.MANV = User.FindFirst("MANV")?.Value;
                if (string.IsNullOrEmpty(veXe.MANV))
                {
                    ModelState.AddModelError("", "Không thể xác định nhân viên đăng nhập.");
                    return View(veXe);
                }

                // Kiểm tra ghế còn trống
                var ghe = await _context.SoGheSoGiuongs
                    .FirstOrDefaultAsync(g => g.MaSoGhe == veXe.MaSoGhe && g.MaChuyen == veXe.MaChuyen);
                if (ghe == null || ghe.TrangThai != "Trống") // Sửa từ "Còn trống"
                {
                    ModelState.AddModelError("MaSoGhe", "Ghế không tồn tại hoặc đã được đặt.");
                    return View(veXe);
                }
                ghe.TrangThai = "Đã đặt";

                // Kiểm tra chuyến xe
                var chuyenXe = await _context.ChuyenXes.FindAsync(veXe.MaChuyen);
                if (chuyenXe == null || chuyenXe.TrangThai != "Hoạt động")
                {
                    ModelState.AddModelError("MaChuyen", "Chuyến xe không tồn tại hoặc không hoạt động.");
                    return View(veXe);
                }

                veXe.TrangThai = "Đã đặt";
                veXe.NgayDatVe = DateTime.Now;
                _context.Add(veXe);
                ghe.TrangThai = "Đã đặt"; // Cập nhật trạng thái ghế

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ChuyenXes = _context.ChuyenXes.Where(c => c.TrangThai == "Hoạt động").ToList();
            ViewBag.SoGheSoGiuongs = _context.SoGheSoGiuongs.Where(s => s.TrangThai == "Còn trống").ToList();
            return View(veXe);
        }

        // Sửa vé (GET)
        public async Task<IActionResult> Edit(string id)
        {
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                    .ThenInclude(c => c.TuyenXe)
                .Include(v => v.KhachHang)
                .Include(v => v.VeXe_SoGhes)
                .FirstOrDefaultAsync(v => v.MaVeXe == id);
            if (veXe == null)
            {
                return NotFound();
            }

            if (veXe.ChuyenXe.TrangThai == "Đã khởi hành" || veXe.ChuyenXe.NgayKhoiHanh < DateTime.Now)
            {
                TempData["Error"] = "Không thể sửa vé của chuyến xe đã khởi hành.";
                return RedirectToAction(nameof(Index));
            }

            var chuyenXes = _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Where(c => c.TrangThai == "Chưa khởi hành" && c.NgayKhoiHanh > DateTime.Now)
                .Select(c => new SelectListItem
                {
                    Value = c.MaChuyen,
                    Text = (c.TuyenXe != null ? c.TuyenXe.DiemDi : "Không xác định") + " - " + (c.TuyenXe != null ? c.TuyenXe.DiemDen : "Không xác định") + " (" + c.NgayKhoiHanh.ToShortDateString() + " " + c.GioKhoiHanh + ")"
                }).ToList();

            ViewBag.ChuyenXes = chuyenXes;
            ViewBag.KhachHangs = _context.KhachHangs
                .Select(k => new SelectListItem
                {
                    Value = k.MaKh,
                    Text = $"{k.HovaTen} ({k.MaKh})"
                }).ToList();

            ViewBag.SoGheSoGiuongs = _context.SoGheSoGiuongs
                .Where(s => (s.MaChuyen == veXe.MaChuyen && s.TrangThai == "Trống") || s.MaSoGhe == veXe.MaSoGhe)
                .ToList();

            ViewData["CurrentMaXe"] = veXe.MaXe;

            return View(veXe);
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableSeats(string maChuyen)
        {
            var chuyenXe = await _context.ChuyenXes
                .FirstOrDefaultAsync(c => c.MaChuyen == maChuyen);
            if (chuyenXe == null)
            {
                Console.WriteLine($"Không tìm thấy ChuyenXe với MaChuyen = {maChuyen}");
                return Json(new { seats = new List<object>(), maXe = "" });
            }

            var availableSeats = await _context.SoGheSoGiuongs
                .Where(s => s.MaChuyen == maChuyen && s.MaXe == chuyenXe.MaXe && s.TrangThai == "Trống") // Sửa thành "Trống"
                .Select(s => new
                {
                    Value = s.MaSoGhe,
                    Text = s.MaSoGhe
                })
                .ToListAsync();

            var response = new { seats = availableSeats, maXe = chuyenXe.MaXe };
            Console.WriteLine($"MaChuyen = {maChuyen}, MaXe = {chuyenXe.MaXe}, Số ghế trống = {availableSeats.Count}, Response = {System.Text.Json.JsonSerializer.Serialize(response)}");

            if (availableSeats.Count == 0)
            {
                var allSeats = await _context.SoGheSoGiuongs
                    .Where(s => s.MaChuyen == maChuyen && s.MaXe == chuyenXe.MaXe)
                    .ToListAsync();
                Console.WriteLine($"Tất cả ghế: {allSeats.Count}, Trạng thái: {string.Join(", ", allSeats.Select(s => s.TrangThai))}");
            }

            return Json(response);
        }
        // Sửa vé (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, VeXe veXe)
        {
            if (id != veXe.MaVeXe)
            {
                return NotFound();
            }

            var veXeToUpdate = await _context.VeXes
                .FirstOrDefaultAsync(v => v.MaVeXe == id);
            if (veXeToUpdate == null)
            {
                return NotFound();
            }

            // Lưu giá trị cũ để so sánh
            int oldSoLuongVe = veXeToUpdate.SoLuongVe;

            // Cập nhật các trường từ dữ liệu POST
            veXeToUpdate.MaChuyen = veXe.MaChuyen;
            veXeToUpdate.MaKh = veXe.MaKh;
            veXeToUpdate.MaSoGhe = veXe.MaSoGhe;
            veXeToUpdate.MaXe = veXe.MaXe;
            veXeToUpdate.SoLuongVe = veXe.SoLuongVe;
            veXeToUpdate.TrangThai = veXe.TrangThai;

            // Xóa lỗi ModelState liên quan đến navigation properties
            ModelState.Remove("ChuyenXe");
            ModelState.Remove("NhanVien");
            ModelState.Remove("KhachHang");
            ModelState.Remove("VeXe_SoGhes");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine($"ModelState không hợp lệ: {string.Join(", ", errors)}");
                TempData["Error"] = "Có lỗi khi cập nhật vé: " + string.Join(", ", errors);
                await LoadViewBagData(veXeToUpdate);
                return View(veXeToUpdate);
            }

            try
            {
                var chuyenXe = await _context.ChuyenXes.FindAsync(veXeToUpdate.MaChuyen);
                if (chuyenXe == null || chuyenXe.TrangThai == "Đã khởi hành" || chuyenXe.NgayKhoiHanh < DateTime.Now)
                {
                    ModelState.AddModelError("MaChuyen", "Chuyến xe không hợp lệ hoặc đã khởi hành.");
                    await LoadViewBagData(veXeToUpdate);
                    return View(veXeToUpdate);
                }

                if (veXeToUpdate.MaSoGhe != veXe.MaSoGhe || veXeToUpdate.MaChuyen != veXe.MaChuyen)
                {
                    var oldGhe = await _context.SoGheSoGiuongs
                        .FirstOrDefaultAsync(g => g.MaSoGhe == veXeToUpdate.MaSoGhe && g.MaChuyen == veXeToUpdate.MaChuyen && g.MaXe == veXeToUpdate.MaXe);
                    var newGhe = await _context.SoGheSoGiuongs
                        .FirstOrDefaultAsync(g => g.MaSoGhe == veXe.MaSoGhe && g.MaChuyen == veXe.MaChuyen && g.MaXe == veXe.MaXe);

                    if (newGhe == null || newGhe.TrangThai != "Trống")
                    {
                        ModelState.AddModelError("MaSoGhe", "Ghế mới không tồn tại hoặc đã được đặt.");
                        await LoadViewBagData(veXeToUpdate);
                        return View(veXeToUpdate);
                    }

                    if (oldGhe != null) oldGhe.TrangThai = "Trống";
                    newGhe.TrangThai = "Đã đặt";
                }

                if (veXeToUpdate.SoLuongVe > oldSoLuongVe) // So sánh với giá trị cũ
                {
                    var soGheConTrong = _context.SoGheSoGiuongs
                        .Count(s => s.MaChuyen == veXeToUpdate.MaChuyen && s.MaXe == veXeToUpdate.MaXe && s.TrangThai == "Trống");
                    if (soGheConTrong < (veXeToUpdate.SoLuongVe - oldSoLuongVe))
                    {
                        ModelState.AddModelError("SoLuongVe", "Không đủ ghế trống để tăng số lượng vé.");
                        await LoadViewBagData(veXeToUpdate);
                        return View(veXeToUpdate);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã cập nhật vé xe thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.VeXes.Any(e => e.MaVeXe == veXeToUpdate.MaVeXe))
                {
                    return NotFound();
                }
                throw;
            }
        }
        // Hàm hỗ trợ load ViewBag
        private async Task LoadViewBagData(VeXe veXe)
        {
            ViewBag.ChuyenXes = _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Where(c => c.TrangThai == "Chưa khởi hành" && c.NgayKhoiHanh > DateTime.Now)
                .Select(c => new SelectListItem
                {
                    Value = c.MaChuyen,
                    Text = (c.TuyenXe != null ? c.TuyenXe.DiemDi : "Không xác định") + " - " + (c.TuyenXe != null ? c.TuyenXe.DiemDen : "Không xác định") + " (" + c.NgayKhoiHanh.ToShortDateString() + " " + c.GioKhoiHanh + ")"
                }).ToList();

            ViewBag.KhachHangs = _context.KhachHangs
                .Select(k => new SelectListItem
                {
                    Value = k.MaKh,
                    Text = $"{k.HovaTen} ({k.MaKh})"
                }).ToList();

            ViewBag.SoGheSoGiuongs = _context.SoGheSoGiuongs
                .Where(s => (s.MaChuyen == veXe.MaChuyen && s.TrangThai == "Trống") || s.MaSoGhe == veXe.MaSoGhe)
                .ToList();
        }
        // Hủy vé (GET)
        // Hủy vé (GET)
        public async Task<IActionResult> Delete(string id)
        {
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .Include(v => v.KhachHang)
                .FirstOrDefaultAsync(v => v.MaVeXe == id);
            if (veXe == null)
            {
                return NotFound();
            }

            // Kiểm tra xem vé có thể hủy được không
            if (veXe.ChuyenXe.TrangThai == "Đã khởi hành" || veXe.ChuyenXe.NgayKhoiHanh < DateTime.Now)
            {
                TempData["Error"] = "Không thể hủy vé của chuyến xe đã khởi hành.";
                return RedirectToAction(nameof(Index));
            }

            if (veXe.TrangThai == "Đã hủy")
            {
                TempData["Error"] = "Vé này đã được hủy trước đó.";
                return RedirectToAction(nameof(Index));
            }

            return View(veXe);
        }

        // Hủy vé (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var veXe = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .FirstOrDefaultAsync(v => v.MaVeXe == id);
            if (veXe == null)
            {
                return NotFound();
            }

            // Kiểm tra lại điều kiện hủy
            if (veXe.ChuyenXe.TrangThai == "Đã khởi hành" || veXe.ChuyenXe.NgayKhoiHanh < DateTime.Now)
            {
                TempData["Error"] = "Không thể hủy vé vì chuyến xe đã khởi hành.";
                return RedirectToAction(nameof(Index));
            }

            if (veXe.TrangThai == "Đã hủy")
            {
                TempData["Error"] = "Vé này đã được hủy trước đó.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                // Cập nhật trạng thái vé
                veXe.TrangThai = "Đã hủy";

                // Giải phóng ghế
                var ghe = await _context.SoGheSoGiuongs
                    .FirstOrDefaultAsync(g => g.MaSoGhe == veXe.MaSoGhe && g.MaChuyen == veXe.MaChuyen && g.MaXe == veXe.MaXe);
                if (ghe != null && ghe.TrangThai == "Đã đặt")
                {
                    ghe.TrangThai = "Trống";
                }

                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã hủy vé xe thành công.";
            }
            catch (DbUpdateException ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi hủy vé: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}