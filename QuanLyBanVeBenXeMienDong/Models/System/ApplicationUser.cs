using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuanLyBanVeBenXeMienDong.Models.System
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string HovaTen { get; set; }
        public string? CCCD { get; set; }
        public string? MaKh { get; set; } 
        public string? MANV { get; set; }
    }
}
