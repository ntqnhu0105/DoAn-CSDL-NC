using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyBanVeBenXeMienDong.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tang",
                table: "SoGheSoGiuongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A01", "XE001" },
                column: "Tang",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A02", "XE001" },
                column: "Tang",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A03", "XE001" },
                column: "Tang",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX008", "A04", "XE001" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX002", "B01", "XE002" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX002", "B02", "XE002" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX002", "B03", "XE002" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX007", "B04", "XE002" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX003", "C01", "XE003" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX003", "C02", "XE003" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX004", "D01", "XE004" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX004", "D02", "XE004" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX009", "D03", "XE004" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX005", "E01", "XE005" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX005", "E02", "XE005" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX006", "F01", "XE006" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX006", "F02", "XE006" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX010", "G01", "XE007" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX010", "G02", "XE007" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX011", "H01", "XE008" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX011", "H02", "XE008" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX012", "I01", "XE009" },
                column: "Tang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX012", "I02", "XE009" },
                column: "Tang",
                value: 0);

            migrationBuilder.InsertData(
                table: "SoGheSoGiuongs",
                columns: new[] { "MaChuyen", "MaSoGhe", "MaXe", "ChuyenXeMaChuyen", "Tang", "TrangThai" },
                values: new object[,]
                {
                    { "CX001", "A04", "XE001", null, 1, "Trống" },
                    { "CX001", "A05", "XE001", null, 1, "Trống" },
                    { "CX001", "A06", "XE001", null, 1, "Trống" },
                    { "CX001", "A07", "XE001", null, 1, "Trống" },
                    { "CX001", "A08", "XE001", null, 1, "Trống" },
                    { "CX001", "A09", "XE001", null, 1, "Trống" },
                    { "CX001", "A10", "XE001", null, 1, "Trống" },
                    { "CX001", "A11", "XE001", null, 1, "Trống" },
                    { "CX001", "A12", "XE001", null, 1, "Trống" },
                    { "CX001", "A13", "XE001", null, 1, "Trống" },
                    { "CX001", "A14", "XE001", null, 1, "Trống" },
                    { "CX001", "A15", "XE001", null, 1, "Trống" },
                    { "CX001", "A16", "XE001", null, 1, "Trống" },
                    { "CX001", "A17", "XE001", null, 1, "Trống" },
                    { "CX001", "A18", "XE001", null, 1, "Trống" },
                    { "CX001", "A19", "XE001", null, 1, "Trống" },
                    { "CX001", "A20", "XE001", null, 1, "Trống" },
                    { "CX001", "B01", "XE001", null, 2, "Trống" },
                    { "CX001", "B02", "XE001", null, 2, "Trống" },
                    { "CX001", "B03", "XE001", null, 2, "Trống" },
                    { "CX001", "B04", "XE001", null, 2, "Trống" },
                    { "CX001", "B05", "XE001", null, 2, "Trống" },
                    { "CX001", "B06", "XE001", null, 2, "Trống" },
                    { "CX001", "B07", "XE001", null, 2, "Trống" },
                    { "CX001", "B08", "XE001", null, 2, "Trống" },
                    { "CX001", "B09", "XE001", null, 2, "Trống" },
                    { "CX001", "B10", "XE001", null, 2, "Trống" },
                    { "CX001", "B11", "XE001", null, 2, "Trống" },
                    { "CX001", "B12", "XE001", null, 2, "Trống" },
                    { "CX001", "B13", "XE001", null, 2, "Trống" },
                    { "CX001", "B14", "XE001", null, 2, "Trống" },
                    { "CX001", "B15", "XE001", null, 2, "Trống" },
                    { "CX001", "B16", "XE001", null, 2, "Trống" },
                    { "CX001", "B17", "XE001", null, 2, "Trống" },
                    { "CX001", "B18", "XE001", null, 2, "Trống" },
                    { "CX001", "B19", "XE001", null, 2, "Trống" },
                    { "CX001", "B20", "XE001", null, 2, "Trống" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A04", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A05", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A06", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A07", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A08", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A09", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A10", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A11", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A12", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A13", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A14", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A15", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A16", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A17", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A18", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A19", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "A20", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B01", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B02", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B03", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B04", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B05", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B06", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B07", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B08", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B09", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B10", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B11", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B12", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B13", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B14", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B15", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B16", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B17", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B18", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B19", "XE001" });

            migrationBuilder.DeleteData(
                table: "SoGheSoGiuongs",
                keyColumns: new[] { "MaChuyen", "MaSoGhe", "MaXe" },
                keyValues: new object[] { "CX001", "B20", "XE001" });

            migrationBuilder.DropColumn(
                name: "Tang",
                table: "SoGheSoGiuongs");

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX001",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 1, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX002",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 1, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX003",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX004",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 1, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX005",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX006",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 1, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX007",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX008",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX009",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX010",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 1, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX011",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 2, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "ChuyenXes",
                keyColumn: "MaChuyen",
                keyValue: "CX012",
                column: "NgayKhoiHanh",
                value: new DateTime(2025, 4, 3, 19, 40, 8, 694, DateTimeKind.Local).AddTicks(8069));
        }
    }
}
