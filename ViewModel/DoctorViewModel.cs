using Cms.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Web.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string title { get; set; }
        public int PoliclinicId { get; set; }
        public string? PoliclinicName { get; set; }
        [ValidateNever]
        [NotMapped]
        public IFormFile? Image { get; set; }
        [ValidateNever]
        public string? ImagePath { get; set; }
    }
}
