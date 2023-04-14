namespace Cms.Web.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Opinion { get; set; }
        public DateTime Created { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
