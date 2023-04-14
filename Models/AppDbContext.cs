using Microsoft.EntityFrameworkCore;
using Cms.Web.ViewModel;

namespace Cms.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminLayout> AdminLayouts { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Referans> Referanss { get; set; }

        
    }
}
