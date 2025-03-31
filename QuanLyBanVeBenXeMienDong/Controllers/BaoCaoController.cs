using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;
using QuanLyBanVeBenXeMienDong.Models.System;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ClosedXML.Excel;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Layout.Properties;
using iText.Kernel.Geom;

namespace QuanLyBanVeBenXeMienDong.Controllers
{
    [Authorize(Roles = "NhanVien")]
    public class BaoCaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaoCaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Báo cáo doanh thu
        public async Task<IActionResult> RevenueReport([FromQuery] string startDate, [FromQuery] string endDate)
        {
            DateTime? parsedStartDate = null;
            DateTime? parsedEndDate = null;

            CultureInfo culture = new CultureInfo("en-US");
            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParseExact(startDate, "yyyy-MM-dd", culture, DateTimeStyles.None, out DateTime start))
            {
                parsedStartDate = start;
            }
            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParseExact(endDate, "yyyy-MM-dd", culture, DateTimeStyles.None, out DateTime end))
            {
                parsedEndDate = end.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
            }

            if (!parsedStartDate.HasValue)
            {
                parsedStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            }
            if (!parsedEndDate.HasValue)
            {
                parsedEndDate = DateTime.Now;
            }

            if (parsedStartDate > parsedEndDate)
            {
                TempData["Error"] = "Ngày bắt đầu không thể lớn hơn ngày kết thúc.";
                parsedStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                parsedEndDate = DateTime.Now;
            }

            var veXes = await _context.VeXes
                .Include(v => v.ChuyenXe)
                .Include(v => v.KhachHang)
                .Where(v => v.NgayDatVe >= parsedStartDate && v.NgayDatVe <= parsedEndDate && v.TrangThai == "Đã thanh toán")
                .ToListAsync();

            decimal totalRevenue = veXes.Sum(v => v.SoLuongVe * GetTicketPrice(v));

            ViewBag.StartDate = parsedStartDate.Value.ToString("dd/MM/yyyy HH:mm:ss.fff");
            ViewBag.EndDate = parsedEndDate.Value.ToString("dd/MM/yyyy HH:mm:ss.fff");
            ViewBag.TotalRevenue = totalRevenue;

            return View(veXes);
        }

        // Xuất Excel
        [HttpGet]
        public async Task<IActionResult> ExportToExcel(string startDate, string endDate)
        {
            var veXes = await GetFilteredVeXes(startDate, endDate);
            decimal totalRevenue = veXes.Sum(v => v.SoLuongVe * GetTicketPrice(v));

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BaoCaoDoanhThu");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "BÁO CÁO DOANH THU";
                worksheet.Range(currentRow, 1, currentRow, 8).Merge().Style.Font.Bold = true;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = $"Từ: {startDate} Đến: {endDate}";
                worksheet.Range(currentRow, 1, currentRow, 8).Merge();
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Mã vé";
                worksheet.Cell(currentRow, 2).Value = "Chuyến xe";
                worksheet.Cell(currentRow, 3).Value = "Khách hàng";
                worksheet.Cell(currentRow, 4).Value = "Ghế";
                worksheet.Cell(currentRow, 5).Value = "Số lượng vé";
                worksheet.Cell(currentRow, 6).Value = "Trạng thái";
                worksheet.Cell(currentRow, 7).Value = "Ngày đặt";
                worksheet.Cell(currentRow, 8).Value = "Doanh thu";
                worksheet.Range(currentRow, 1, currentRow, 8).Style.Font.Bold = true;
                currentRow++;

                foreach (var veXe in veXes)
                {
                    worksheet.Cell(currentRow, 1).Value = veXe.MaVeXe;
                    worksheet.Cell(currentRow, 2).Value = veXe.MaChuyen;
                    worksheet.Cell(currentRow, 3).Value = $"{veXe.KhachHang?.HovaTen ?? "Không xác định"} ({veXe.MaKh})";
                    worksheet.Cell(currentRow, 4).Value = veXe.MaSoGhe;
                    worksheet.Cell(currentRow, 5).Value = veXe.SoLuongVe;
                    worksheet.Cell(currentRow, 6).Value = veXe.TrangThai;
                    worksheet.Cell(currentRow, 7).Value = veXe.NgayDatVe.ToString("dd/MM/yyyy HH:mm:ss");
                    worksheet.Cell(currentRow, 8).Value = (veXe.SoLuongVe * GetTicketPrice(veXe)).ToString("N0");
                    currentRow++;
                }

                worksheet.Cell(currentRow, 7).Value = "Tổng doanh thu:";
                worksheet.Cell(currentRow, 8).Value = totalRevenue.ToString("N0");
                worksheet.Range(currentRow, 7, currentRow, 8).Style.Font.Bold = true;

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BaoCaoDoanhThu.xlsx");
                }
            }
        }

        // Xuất PDF
        [HttpGet]
        public async Task<IActionResult> ExportToPdf(string startDate, string endDate)
        {
            var veXes = await GetFilteredVeXes(startDate, endDate);
            decimal totalRevenue = veXes.Sum(v => v.SoLuongVe * GetTicketPrice(v));

            using (var stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf, PageSize.A4);
                        document.SetMargins(20, 20, 20, 20);

                        // Font hỗ trợ tiếng Việt (Times New Roman)
                        string fontPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "times.ttf");
                        PdfFont boldFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                        PdfFont regularFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);

                        // Tiêu đề
                        Paragraph title = new Paragraph("BÁO CÁO DOANH THU")
                            .SetFont(boldFont)
                            .SetFontSize(16)
                            .SetTextAlignment(TextAlignment.CENTER);
                        document.Add(title);

                        Paragraph dateRange = new Paragraph($"Từ: {startDate} Đến: {endDate}")
                            .SetFont(regularFont)
                            .SetFontSize(12)
                            .SetTextAlignment(TextAlignment.CENTER);
                        document.Add(dateRange);
                        document.Add(new Paragraph(" ").SetFontSize(10)); // Khoảng cách

                        // Bảng với chiều rộng cột cố định
                        float[] columnWidths = { 60f, 60f, 120f, 60f, 60f, 80f, 120f, 80f }; // Tổng 648f (A4 width ~ 595pt - margins)
                        var table = new Table(UnitValue.CreatePointArray(columnWidths)).UseAllAvailableWidth();

                        // Header bảng
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Mã vé").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Chuyến xe").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Khách hàng").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ghế").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Số lượng vé").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Trạng thái").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ngày đặt").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.CENTER));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Doanh thu").SetFont(boldFont).SetFontSize(10)).SetTextAlignment(TextAlignment.RIGHT));

                        // Dữ liệu
                        foreach (var veXe in veXes)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(veXe.MaVeXe).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph(veXe.MaChuyen).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph($"{veXe.KhachHang?.HovaTen ?? "Không xác định"} ({veXe.MaKh})").SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.LEFT));
                            table.AddCell(new Cell().Add(new Paragraph(veXe.MaSoGhe).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph(veXe.SoLuongVe.ToString()).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph(veXe.TrangThai).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph(veXe.NgayDatVe.ToString("dd/MM/yyyy HH:mm:ss")).SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.CENTER));
                            table.AddCell(new Cell().Add(new Paragraph($"{(veXe.SoLuongVe * GetTicketPrice(veXe)):N0}").SetFont(regularFont).SetFontSize(9)).SetTextAlignment(TextAlignment.RIGHT));
                        }

                        document.Add(table);

                        // Tổng doanh thu
                        Paragraph total = new Paragraph($"Tổng doanh thu: {totalRevenue:N0} VNĐ")
                            .SetFont(boldFont)
                            .SetFontSize(12)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetMarginTop(10);
                        document.Add(total);

                        document.Close();
                    }
                }

                var content = stream.ToArray();
                return File(content, "application/pdf", "BaoCaoDoanhThu.pdf");
            }
        }

        // Hàm hỗ trợ lấy danh sách vé đã lọc
        private async Task<List<VeXe>> GetFilteredVeXes(string startDate, string endDate)
        {
            DateTime? parsedStartDate = null;
            DateTime? parsedEndDate = null;

            CultureInfo culture = new CultureInfo("en-US");
            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParseExact(startDate, "yyyy-MM-dd", culture, DateTimeStyles.None, out DateTime start))
            {
                parsedStartDate = start;
            }
            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParseExact(endDate, "yyyy-MM-dd", culture, DateTimeStyles.None, out DateTime end))
            {
                parsedEndDate = end.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
            }

            if (!parsedStartDate.HasValue) parsedStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            if (!parsedEndDate.HasValue) parsedEndDate = DateTime.Now;

            return await _context.VeXes
                .Include(v => v.ChuyenXe)
                .Include(v => v.KhachHang)
                .Where(v => v.NgayDatVe >= parsedStartDate && v.NgayDatVe <= parsedEndDate && v.TrangThai == "Đã thanh toán")
                .ToListAsync();
        }

        private decimal GetTicketPrice(VeXe veXe)
        {
            return veXe.ChuyenXe?.Gia ?? 100000;
        }
    }
}