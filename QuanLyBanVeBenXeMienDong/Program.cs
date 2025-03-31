using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new System.Globalization.CultureInfo("en-US") };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false; // Không yêu cầu xác nhận email
    options.User.RequireUniqueEmail = true; // Đảm bảo email là duy nhất
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRequestLocalization();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Tạo role NhanVien nếu chưa tồn tại
    if (!await roleManager.RoleExistsAsync("NhanVien"))
    {
        await roleManager.CreateAsync(new IdentityRole("NhanVien"));
    }

    // Tìm nhân viên NV000
    var nhanVien = await context.NhanViens.FirstOrDefaultAsync(nv => nv.MANV == "NV000");
    if (nhanVien != null)
    {
        var user = await userManager.FindByNameAsync(nhanVien.MANV);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = nhanVien.MANV,
                Email = nhanVien.Email ?? "thuy@gmail.com", // Đảm bảo email khớp
                EmailConfirmed = true,
                HovaTen = nhanVien.HovaTen ?? "Nhân Viên NV000",
                MANV = nhanVien.MANV
            };
            var result = await userManager.CreateAsync(user, "NhanVien123!");
            if (!result.Succeeded)
            {
                throw new Exception("Không thể tạo user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        // Gán role NhanVien
        if (!await userManager.IsInRoleAsync(user, "NhanVien"))
        {
            await userManager.AddToRoleAsync(user, "NhanVien");
        }
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
