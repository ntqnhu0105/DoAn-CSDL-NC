using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyBanVeBenXeMienDong.Migrations
{
    /// <inheritdoc />
    public partial class AddHCMToDaLatRouteDataForTX001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaDiemDon",
                table: "VeXes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaDiemTra",
                table: "VeXes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX001",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX002",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX003",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX004",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX005",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX006",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX007",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX008",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 4, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX009",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX010",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX011",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX012",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 4, 7, 24, 33, 906, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.InsertData(
                table: "Diems",
                columns: new[] { "MaDiem", "DiaChi", "LoaiDiem", "MaTuyen", "TenDiem", "ToaDoGPS" },
                values: new object[,]
                {
                    { "D001", "501 Hoàng Hữu Nam, Long Bình, Thủ Đức", "Điểm đón", "TX001", "Bến xe Miền Đông Mới", "10.947, 106.843" },
                    { "D002", "293 Phạm Ngũ Lão, Quận 1, TP. HCM", "Điểm đón", "TX001", "Văn phòng Quận 1", "10.768, 106.693" },
                    { "D003", "QL1A, Linh Trung, Thủ Đức, TP. HCM", "Điểm đón", "TX001", "Ngã tư Thủ Đức", "10.863, 106.776" },
                    { "D004", "1 Tô Hiến Thành, Phường 3, Đà Lạt", "Điểm trả", "TX001", "Bến xe Liên Tỉnh Đà Lạt", "11.940, 108.458" },
                    { "D005", "17 Lương Thế Vinh, Phường 3, Đà Lạt", "Điểm trả", "TX001", "Văn phòng Đà Lạt", "11.945, 108.435" },
                    { "D006", "2 Lê Hồng Phong, Phường 4, Đà Lạt", "Điểm trả", "TX001", "Khách sạn TTC Đà Lạt", "11.944, 108.438" }
                });

            migrationBuilder.InsertData(
                table: "ChuyenXe_Diems",
                columns: new[] { "MaChuyen", "MaDiem", "ThoiGianDuKien" },
                values: new object[,]
                {
                    { "CX001", "D001", new TimeSpan(0, 7, 0, 0, 0) },
                    { "CX001", "D002", new TimeSpan(0, 7, 30, 0, 0) },
                    { "CX001", "D003", new TimeSpan(0, 7, 45, 0, 0) },
                    { "CX001", "D004", new TimeSpan(0, 13, 0, 0, 0) },
                    { "CX001", "D005", new TimeSpan(0, 13, 15, 0, 0) },
                    { "CX001", "D006", new TimeSpan(0, 13, 30, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D001" });

            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D002" });

            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D003" });

            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D004" });

            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D005" });

            migrationBuilder.DeleteData(
                table: "ChuyenXe_Diems",
                keyColumns: new[] { "MaChuyen", "MaDiem" },
                keyValues: new object[] { "CX001", "D006" });

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D001");

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D002");

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D003");

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D004");

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D005");

            migrationBuilder.DeleteData(
                table: "Diems",
                keyColumn: "MaDiem",
                keyValue: "D006");

            migrationBuilder.DropColumn(
                name: "MaDiemDon",
                table: "VeXes");

            migrationBuilder.DropColumn(
                name: "MaDiemTra",
                table: "VeXes");

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX001",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX002",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX003",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX004",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX005",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX006",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX007",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX008",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 4, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX009",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX010",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX011",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX012",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 4, 3, 16, 48, 523, DateTimeKind.Local).AddTicks(7496));
        }
    }
}
