using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Models
{
    public class AdminLayout
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Linkedn { get; set; }
        public string? FooterText { get; set; }
    }
}
