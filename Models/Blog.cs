namespace Cms.Web.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Sendtime { get; set; }
        public string? ImagePath { get; set; }
        public List<Comment>? comments { get; set; }


    }
}
