using Cms.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Web.ViewModel
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime? Sendtime { get; set; }

        [ValidateNever]
        [NotMapped]
        public IFormFile? Image { get; set; }
        [ValidateNever]
        public string? ImagePath { get; set; }
        public IEnumerable<Comment>? Comments  { get; set; }
    }
}
