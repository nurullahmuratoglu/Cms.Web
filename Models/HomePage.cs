namespace Cms.Web.Models
{
	public class HomePage
	{
        public int Id { get; set; }
        public string? WorkingHours { get; set; }
        public int? TotalExamined{ get; set; }
        public int? TotalOperation { get; set; }
        public int? TotalDoctor { get; set; }
    }
}
