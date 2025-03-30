using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyBanVeBenXeMienDong.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MANV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MucGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXes",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoLuongGhe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXes", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaXes",
                columns: table => new
                {
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNhaXe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXes", x => x.MaNhaXe);
                });

            migrationBuilder.CreateTable(
                name: "TaiXes",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BangLai = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    KinhNghiem = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXes", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "TuyenXes",
                columns: table => new
                {
                    MaTuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiemDi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiemDen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KhoangCach = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThoiGianDuKien = table.Column<TimeSpan>(type: "time", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GiaThamKhao = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenXes", x => x.MaTuyen);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_NhanViens_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "Xes",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xes", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_Xes_LoaiXes_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiXes",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xes_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    MaDiem = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenDiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LoaiDiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ToaDoGPS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.MaDiem);
                    table.ForeignKey(
                        name: "FK_Diems_TuyenXes_MaTuyen",
                        column: x => x.MaTuyen,
                        principalTable: "TuyenXes",
                        principalColumn: "MaTuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuayBanVes",
                columns: table => new
                {
                    MaQuay = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenQuay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuayBanVes", x => x.MaQuay);
                    table.ForeignKey(
                        name: "FK_QuayBanVes_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                    table.ForeignKey(
                        name: "FK_QuayBanVes_NhanViens_MANV",
                        column: x => x.MANV,
                        principalTable: "NhanViens",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXes",
                columns: table => new
                {
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaTuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayKhoiHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKhoiHanh = table.Column<TimeSpan>(type: "time", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXes", x => x.MaChuyen);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_TuyenXes_MaTuyen",
                        column: x => x.MaTuyen,
                        principalTable: "TuyenXes",
                        principalColumn: "MaTuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXe_Diems",
                columns: table => new
                {
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaDiem = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ThoiGianDuKien = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXe_Diems", x => new { x.MaChuyen, x.MaDiem });
                    table.ForeignKey(
                        name: "FK_ChuyenXe_Diems_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_ChuyenXe_Diems_Diems_MaDiem",
                        column: x => x.MaDiem,
                        principalTable: "Diems",
                        principalColumn: "MaDiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanCongs",
                columns: table => new
                {
                    MaPhanCong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaTaiXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayPhanCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongs", x => x.MaPhanCong);
                    table.ForeignKey(
                        name: "FK_PhanCongs_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_PhanCongs_TaiXes_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXes",
                        principalColumn: "MaTaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanHois",
                columns: table => new
                {
                    MaPhanHoi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayPhanHoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHois", x => x.MaPhanHoi);
                    table.ForeignKey(
                        name: "FK_PhanHois_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PhanHois_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanHois_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "SoGheSoGiuongs",
                columns: table => new
                {
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoGheSoGiuongs", x => new { x.MaSoGhe, x.MaXe, x.MaChuyen });
                    table.ForeignKey(
                        name: "FK_SoGheSoGiuongs_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_SoGheSoGiuongs_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeXes",
                columns: table => new
                {
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgayDatVe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXes", x => x.MaVeXe);
                    table.ForeignKey(
                        name: "FK_VeXes_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_VeXes_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeXes_KhuyenMais_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "MaKhuyenMai",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_VeXes_NhanViens_MANV",
                        column: x => x.MANV,
                        principalTable: "NhanViens",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoanTiens",
                columns: table => new
                {
                    MaHoanTien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoTienHoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayYeuCau = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoanTiens", x => x.MaHoanTien);
                    table.ForeignKey(
                        name: "FK_HoanTiens_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoanTiens_VeXes_MaVeXe",
                        column: x => x.MaVeXe,
                        principalTable: "VeXes",
                        principalColumn: "MaVeXe");
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    MaGiaoDich = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_ThanhToans_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToans_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                    table.ForeignKey(
                        name: "FK_ThanhToans_VeXes_MaVeXe",
                        column: x => x.MaVeXe,
                        principalTable: "VeXes",
                        principalColumn: "MaVeXe");
                });

            migrationBuilder.CreateTable(
                name: "VeXe_SoGhes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXe_SoGhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeXe_SoGhes_SoGheSoGiuongs_MaSoGhe_MaXe_MaChuyen",
                        columns: x => new { x.MaSoGhe, x.MaXe, x.MaChuyen },
                        principalTable: "SoGheSoGiuongs",
                        principalColumns: new[] { "MaSoGhe", "MaXe", "MaChuyen" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeXe_SoGhes_VeXes_MaVeXe",
                        column: x => x.MaVeXe,
                        principalTable: "VeXes",
                        principalColumn: "MaVeXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoaiXes",
                columns: new[] { "MaLoai", "MoTa", "SoLuongGhe", "TenLoai" },
                values: new object[,]
                {
                    { "LX001", "Xe cao cấp, có điều hòa", 40, "Xe giường nằm" },
                    { "LX002", "Xe phổ thông", 45, "Xe ghế ngồi" },
                    { "LX003", "Xe sang trọng, ít ghế", 20, "Xe limousine" },
                    { "LX004", "Xe cao cấp, ghế rộng", 30, "Xe VIP" }
                });

            migrationBuilder.InsertData(
                table: "NhaXes",
                columns: new[] { "MaNhaXe", "DiaChi", "Email", "SDT", "TenNhaXe" },
                values: new object[,]
                {
                    { "NX001", "292 Đinh Bộ Lĩnh, TP.HCM", "mien_dong@gmail.com", "0901234567", "Nhà xe Miền Đông" },
                    { "NX002", "80 Trần Hưng Đạo, TP.HCM", "phuongtrang@gmail.com", "0909876543", "Nhà xe Phương Trang" },
                    { "NX003", "266 Lê Hồng Phong, TP.HCM", "thanhbuoi@gmail.com", "0912345678", "Nhà xe Thành Bưởi" },
                    { "NX004", "5 Phạm Ngũ Lão, Hà Nội", "hoanglong@gmail.com", "0987654321", "Nhà xe Hoàng Long" },
                    { "NX005", "102 Nguyễn Văn Trỗi, TP.HCM", "mailinh@gmail.com", "0918889999", "Nhà xe Mai Linh" },
                    { "NX006", "50 Lê Văn Lương, TP.HCM", "futa@gmail.com", "0923456789", "Nhà xe Futa Bus Lines" },
                    { "NX007", "12 Võ Thị Sáu, TP.HCM", "thanhcong@gmail.com", "0904455667", "Nhà xe Thành Công" },
                    { "NX008", "22 Nguyễn Huệ, TP.HCM", "binhminh@gmail.com", "0966668888", "Nhà xe Bình Minh" }
                });

            migrationBuilder.InsertData(
                table: "TuyenXes",
                columns: new[] { "MaTuyen", "DiemDen", "DiemDi", "GiaThamKhao", "KhoangCach", "MoTa", "ThoiGianDuKien" },
                values: new object[,]
                {
                    { "TX001", "Đà Lạt", "TP. Hồ Chí Minh", 250000m, 300m, "Tuyến đường cao tốc, có cảnh đẹp", new TimeSpan(0, 6, 0, 0, 0) },
                    { "TX002", "Hải Phòng", "Hà Nội", 100000m, 120m, "Tuyến ngắn, thuận tiện", new TimeSpan(0, 2, 0, 0, 0) },
                    { "TX003", "Huế", "Đà Nẵng", 120000m, 100m, "Tuyến ven biển, phong cảnh đẹp", new TimeSpan(0, 2, 30, 0, 0) },
                    { "TX004", "Nha Trang", "TP. Hồ Chí Minh", 300000m, 450m, "Tuyến dài, có nghỉ trạm", new TimeSpan(0, 8, 0, 0, 0) },
                    { "TX005", "Sa Pa", "Hà Nội", 280000m, 320m, "Tuyến miền núi, cảnh đẹp", new TimeSpan(0, 6, 30, 0, 0) },
                    { "TX006", "TP. Hồ Chí Minh", "Cần Thơ", 150000m, 170m, "Tuyến đồng bằng, nhanh chóng", new TimeSpan(0, 3, 30, 0, 0) },
                    { "TX007", "Cà Mau", "TP. Hồ Chí Minh", 280000m, 350m, "Tuyến đường về miền Tây", new TimeSpan(0, 7, 0, 0, 0) },
                    { "TX008", "Thanh Hóa", "Hà Nội", 150000m, 160m, "Tuyến phía Bắc tiện lợi", new TimeSpan(0, 3, 30, 0, 0) },
                    { "TX009", "Quảng Ngãi", "Đà Nẵng", 130000m, 120m, "Tuyến miền Trung nhanh chóng", new TimeSpan(0, 2, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "MANV", "CCCD", "ChucVu", "DiaChi", "Email", "HovaTen", "MaNhaXe", "NgaySinh", "SDT" },
                values: new object[] { "NV000", "056304007372", "Nhân viên", null, "thuy@gmail.com", "Nguyễn Thanh Thúy", "NX001", null, "0123456789" });

            migrationBuilder.InsertData(
                table: "Xes",
                columns: new[] { "MaXe", "BienSoXe", "MaLoai", "MaNhaXe" },
                values: new object[,]
                {
                    { "XE001", "51B-12345", "LX001", "NX001" },
                    { "XE002", "29A-54321", "LX002", "NX002" },
                    { "XE003", "51B-67890", "LX003", "NX003" },
                    { "XE004", "30A-11111", "LX004", "NX004" },
                    { "XE005", "51B-22222", "LX001", "NX001" },
                    { "XE006", "29A-33333", "LX002", "NX002" },
                    { "XE007", "51B-77777", "LX003", "NX005" },
                    { "XE008", "29A-88888", "LX002", "NX006" },
                    { "XE009", "51B-99999", "LX004", "NX007" },
                    { "XE010", "50B-12345", "LX001", "NX008" }
                });

            migrationBuilder.InsertData(
                table: "ChuyenXes",
                columns: new[] { "MaChuyen", "Gia", "GioKhoiHanh", "MaTuyen", "MaXe", "NgayKhoiHanh", "TrangThai" },
                values: new object[,]
                {
                    { "CX001", 250000m, new TimeSpan(0, 7, 0, 0, 0), "TX001", "XE001", new DateTime(2025, 3, 31, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(8976), "Chưa khởi hành" },
                    { "CX002", 100000m, new TimeSpan(0, 9, 0, 0, 0), "TX002", "XE002", new DateTime(2025, 3, 31, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(8998), "Chưa khởi hành" },
                    { "CX003", 120000m, new TimeSpan(0, 14, 0, 0, 0), "TX003", "XE003", new DateTime(2025, 4, 1, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9001), "Chưa khởi hành" },
                    { "CX004", 300000m, new TimeSpan(0, 8, 0, 0, 0), "TX004", "XE004", new DateTime(2025, 3, 31, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9003), "Chưa khởi hành" },
                    { "CX005", 280000m, new TimeSpan(0, 20, 0, 0, 0), "TX005", "XE005", new DateTime(2025, 4, 1, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9006), "Chưa khởi hành" },
                    { "CX006", 150000m, new TimeSpan(0, 13, 0, 0, 0), "TX006", "XE006", new DateTime(2025, 3, 31, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9008), "Chưa khởi hành" },
                    { "CX007", 100000m, new TimeSpan(0, 15, 0, 0, 0), "TX002", "XE002", new DateTime(2025, 4, 1, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9010), "Chưa khởi hành" },
                    { "CX008", 250000m, new TimeSpan(0, 10, 0, 0, 0), "TX001", "XE001", new DateTime(2025, 4, 2, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9012), "Chưa khởi hành" },
                    { "CX009", 300000m, new TimeSpan(0, 17, 0, 0, 0), "TX004", "XE004", new DateTime(2025, 4, 1, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9014), "Chưa khởi hành" },
                    { "CX010", 280000m, new TimeSpan(0, 5, 0, 0, 0), "TX007", "XE007", new DateTime(2025, 3, 31, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9016), "Chưa khởi hành" },
                    { "CX011", 150000m, new TimeSpan(0, 14, 0, 0, 0), "TX008", "XE008", new DateTime(2025, 4, 1, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9018), "Chưa khởi hành" },
                    { "CX012", 130000m, new TimeSpan(0, 8, 0, 0, 0), "TX009", "XE009", new DateTime(2025, 4, 2, 13, 10, 40, 462, DateTimeKind.Local).AddTicks(9020), "Chưa khởi hành" }
                });

            migrationBuilder.InsertData(
                table: "SoGheSoGiuongs",
                columns: new[] { "MaChuyen", "MaSoGhe", "MaXe", "TrangThai" },
                values: new object[,]
                {
                    { "CX001", "A01", "XE001", "Trống" },
                    { "CX001", "A02", "XE001", "Trống" },
                    { "CX001", "A03", "XE001", "Trống" },
                    { "CX008", "A04", "XE001", "Trống" },
                    { "CX002", "B01", "XE002", "Trống" },
                    { "CX002", "B02", "XE002", "Trống" },
                    { "CX002", "B03", "XE002", "Trống" },
                    { "CX007", "B04", "XE002", "Trống" },
                    { "CX003", "C01", "XE003", "Trống" },
                    { "CX003", "C02", "XE003", "Trống" },
                    { "CX004", "D01", "XE004", "Trống" },
                    { "CX004", "D02", "XE004", "Trống" },
                    { "CX009", "D03", "XE004", "Trống" },
                    { "CX005", "E01", "XE005", "Trống" },
                    { "CX005", "E02", "XE005", "Trống" },
                    { "CX006", "F01", "XE006", "Trống" },
                    { "CX006", "F02", "XE006", "Trống" },
                    { "CX010", "G01", "XE007", "Trống" },
                    { "CX010", "G02", "XE007", "Trống" },
                    { "CX011", "H01", "XE008", "Trống" },
                    { "CX011", "H02", "XE008", "Trống" },
                    { "CX012", "I01", "XE009", "Trống" },
                    { "CX012", "I02", "XE009", "Trống" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXe_Diems_MaDiem",
                table: "ChuyenXe_Diems",
                column: "MaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_MaTuyen",
                table: "ChuyenXes",
                column: "MaTuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_MaXe",
                table: "ChuyenXes",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_MaTuyen",
                table: "Diems",
                column: "MaTuyen");

            migrationBuilder.CreateIndex(
                name: "IX_HoanTiens_MaKh",
                table: "HoanTiens",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoanTiens_MaVeXe",
                table: "HoanTiens",
                column: "MaVeXe");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaNhaXe",
                table: "NhanViens",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_MaChuyen",
                table: "PhanCongs",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_MaTaiXe",
                table: "PhanCongs",
                column: "MaTaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_MaChuyen",
                table: "PhanHois",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_MaKh",
                table: "PhanHois",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_MaNhaXe",
                table: "PhanHois",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_QuayBanVes_MaNhaXe",
                table: "QuayBanVes",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_QuayBanVes_MANV",
                table: "QuayBanVes",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_SoGheSoGiuongs_MaChuyen",
                table: "SoGheSoGiuongs",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SoGheSoGiuongs_MaXe",
                table: "SoGheSoGiuongs",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaKh",
                table: "ThanhToans",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaNhaXe",
                table: "ThanhToans",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaVeXe",
                table: "ThanhToans",
                column: "MaVeXe");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_SoGhes_MaSoGhe_MaXe_MaChuyen",
                table: "VeXe_SoGhes",
                columns: new[] { "MaSoGhe", "MaXe", "MaChuyen" });

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_SoGhes_MaVeXe",
                table: "VeXe_SoGhes",
                column: "MaVeXe");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaChuyen",
                table: "VeXes",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaKh",
                table: "VeXes",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaKhuyenMai",
                table: "VeXes",
                column: "MaKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MANV",
                table: "VeXes",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_Xes_MaLoai",
                table: "Xes",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Xes_MaNhaXe",
                table: "Xes",
                column: "MaNhaXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChuyenXe_Diems");

            migrationBuilder.DropTable(
                name: "HoanTiens");

            migrationBuilder.DropTable(
                name: "PhanCongs");

            migrationBuilder.DropTable(
                name: "PhanHois");

            migrationBuilder.DropTable(
                name: "QuayBanVes");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "VeXe_SoGhes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "TaiXes");

            migrationBuilder.DropTable(
                name: "SoGheSoGiuongs");

            migrationBuilder.DropTable(
                name: "VeXes");

            migrationBuilder.DropTable(
                name: "ChuyenXes");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "TuyenXes");

            migrationBuilder.DropTable(
                name: "Xes");

            migrationBuilder.DropTable(
                name: "LoaiXes");

            migrationBuilder.DropTable(
                name: "NhaXes");
        }
    }
}
