using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Web.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string title { get; set; }
        public int PoliclinicId { get; set; }
        public Policlinic Policlinic { get; set; }
        public string? ImagePath { get; set; }



    }
}
