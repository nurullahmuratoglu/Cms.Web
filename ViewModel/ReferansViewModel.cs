using Cms.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Web.ViewModel
{
    public class ReferansViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [ValidateNever]
        [NotMapped]
        public IFormFile? Image { get; set; }
        [ValidateNever]
        public string? ImagePath { get; set; }
    }
}
