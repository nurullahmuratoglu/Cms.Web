namespace Cms.Web.Models
{
    public class Policlinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<Doctor>? Doctors { get; set; }
    }
}
