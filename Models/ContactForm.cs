namespace Cms.Web.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String Topic { get; set; }
        public String PhoneNumber { get; set; }
        public String Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
