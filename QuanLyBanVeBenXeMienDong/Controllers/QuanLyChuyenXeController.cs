using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;
using QuanLyBanVeBenXeMienDong.Models.System;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanVeBenXeMienDong.Controllers
{
    [Authorize(Roles = "NhanVien")]
    public class QuanLyChuyenXeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<QuanLyChuyenXeController> _logger;
        private async Task<bool> ChuyenXeExists(string maChuyen)
        {
            return await _context.ChuyenXes.AnyAsync(c => c.MaChuyen == maChuyen);
        }
        // Constructor với DI
        public QuanLyChuyenXeController(ApplicationDbContext context, ILogger<QuanLyChuyenXeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /QuanLyChuyenXe/Index
        public async Task<IActionResult> Index()
        {
            var chuyenXes = await _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Include(c => c.Xe)
                .ThenInclude(x => x.LoaiXe)
                .OrderBy(c => c.NgayKhoiHanh)
                .ToListAsync();
            return View(chuyenXes);
        }

        // GET: /QuanLyChuyenXe/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.TuyenXes = await _context.TuyenXes.ToListAsync();
            ViewBag.Xes = await _context.Xes.Include(x => x.LoaiXe).ToListAsync();
            return View();
        }

        // POST: /QuanLyChuyenXe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChuyenXe chuyenXeFromForm)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            //    TempData["ErrorMessage"] = "Validation failed: " + string.Join(", ", errors);
            //    _logger.LogInformation("ChuyenXe received: {@ChuyenXe}", chuyenXeFromForm);
            //    _logger.LogInformation("ModelState Errors: {@Errors}", errors);
            //}

            // Tạo đối tượng ChuyenXe mới để tránh validation không cần thiết
            var chuyenXe = new ChuyenXe
            {
                MaChuyen = "CX" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                MaTuyen = chuyenXeFromForm.MaTuyen,
                MaXe = chuyenXeFromForm.MaXe,
                NgayKhoiHanh = chuyenXeFromForm.NgayKhoiHanh,
                GioKhoiHanh = chuyenXeFromForm.GioKhoiHanh,
                Gia = chuyenXeFromForm.Gia,
                TrangThai = chuyenXeFromForm.TrangThai
                // Các navigation properties như Xe, TuyenXe, VeXes, SoGheSoGiuongs sẽ để mặc định null
            };

            // Kiểm tra dữ liệu thủ công nếu cần
            if (string.IsNullOrEmpty(chuyenXe.MaTuyen) || string.IsNullOrEmpty(chuyenXe.MaXe) ||
                chuyenXe.NgayKhoiHanh == default || string.IsNullOrEmpty(chuyenXe.GioKhoiHanh) ||
                chuyenXe.Gia <= 0 || string.IsNullOrEmpty(chuyenXe.TrangThai))
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.";
                ViewBag.TuyenXes = await _context.TuyenXes.ToListAsync();
                ViewBag.Xes = await _context.Xes.Include(x => x.LoaiXe).ToListAsync();
                return View(chuyenXeFromForm);
            }

            _context.ChuyenXes.Add(chuyenXe);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Thêm chuyến xe thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /QuanLyChuyenXe/Edit/{maChuyen}
        public async Task<IActionResult> Edit(string maChuyen)
        {
            if (string.IsNullOrEmpty(maChuyen))
            {
                return BadRequest("Mã chuyến không hợp lệ.");
            }

            var chuyenXe = await _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Include(c => c.Xe)
                .ThenInclude(x => x.LoaiXe)
                .FirstOrDefaultAsync(c => c.MaChuyen == maChuyen);

            if (chuyenXe == null)
            {
                return NotFound("Chuyến xe không tồn tại.");
            }

            ViewBag.TuyenXes = await _context.TuyenXes.ToListAsync();
            ViewBag.Xes = await _context.Xes.Include(x => x.LoaiXe).ToListAsync();
            return View(chuyenXe);
        }

        // POST: /QuanLyChuyenXe/Edit/{maChuyen}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string maChuyen, ChuyenXe chuyenXeFromForm)
        {
            if (maChuyen != chuyenXeFromForm.MaChuyen)
            {
                return BadRequest("Mã chuyến không khớp.");
            }

            var chuyenXe = await _context.ChuyenXes.FirstOrDefaultAsync(c => c.MaChuyen == maChuyen);
            if (chuyenXe == null)
            {
                return NotFound("Chuyến xe không tồn tại.");
            }

            // Cập nhật các trường từ form
            chuyenXe.MaTuyen = chuyenXeFromForm.MaTuyen;
            chuyenXe.MaXe = chuyenXeFromForm.MaXe;
            chuyenXe.NgayKhoiHanh = chuyenXeFromForm.NgayKhoiHanh;
            chuyenXe.GioKhoiHanh = chuyenXeFromForm.GioKhoiHanh;
            chuyenXe.Gia = chuyenXeFromForm.Gia;
            chuyenXe.TrangThai = chuyenXeFromForm.TrangThai;

            try
            {
                _context.Update(chuyenXe);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Cập nhật chuyến xe thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ChuyenXeExists(chuyenXe.MaChuyen))
                {
                    return NotFound("Chuyến xe không tồn tại.");
                }
                throw;
            }

            ViewBag.TuyenXes = await _context.TuyenXes.ToListAsync();
            ViewBag.Xes = await _context.Xes.Include(x => x.LoaiXe).ToListAsync();
            return View(chuyenXe);
        }

        // POST: /QuanLyChuyenXe/Delete/{maChuyen}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string maChuyen)
        {

            if (string.IsNullOrEmpty(maChuyen))
            {
                TempData["ErrorMessage"] = "Mã chuyến không hợp lệ.";
                return RedirectToAction(nameof(Index));
            }

            var chuyenXe = await _context.ChuyenXes
                .Include(c => c.VeXes)
                .FirstOrDefaultAsync(c => c.MaChuyen == maChuyen);

            if (chuyenXe == null)
            {
                TempData["ErrorMessage"] = "Chuyến xe không tồn tại.";
                return RedirectToAction(nameof(Index));
            }

            if (chuyenXe.VeXes != null && chuyenXe.VeXes.Any())
            {
                TempData["ErrorMessage"] = "Không thể xóa chuyến xe đã có vé đặt.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.ChuyenXes.Remove(chuyenXe);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Đã xóa chuyến xe: {MaChuyen}", maChuyen);
                TempData["SuccessMessage"] = "Xóa chuyến xe thành công!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa chuyến xe: {MaChuyen}", maChuyen);
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa chuyến xe. Vui lòng thử lại.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}