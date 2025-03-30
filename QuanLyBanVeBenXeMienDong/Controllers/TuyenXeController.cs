using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;
using QuanLyBanVeBenXeMienDong.Models.System;

namespace QuanLyBanVeBenXeMienDong.Controllers
{
    public class TuyenXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuyenXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Search(string diemDi, string diemDen)
        {
            var chuyenXes = await _context.ChuyenXes
                .Include(c => c.TuyenXe)
                .Where(c => c.TuyenXe.DiemDi.Contains(diemDi) && c.TuyenXe.DiemDen.Contains(diemDen) && c.TrangThai == "Chưa khởi hành")
                .ToListAsync();

            return View(chuyenXes);
        }
    }
}