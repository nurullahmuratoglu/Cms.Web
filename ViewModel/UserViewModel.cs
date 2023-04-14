using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        //[Remote(action: "HasUserEmail", controller: "User")]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
