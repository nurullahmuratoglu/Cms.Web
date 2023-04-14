using Cms.Web.Models;

namespace Cms.Web.ViewModel
{
    public class HomePageViewModel
    {

        public int Id { get; set; }
        public string? WorkingHours { get; set; }
        public int? TotalExamined { get; set; }
        public int? TotalOperation { get; set; }
        public int? TotalDoctor { get; set; }
        public IEnumerable<Referans>? Referanss { get; set; }
    }
}
