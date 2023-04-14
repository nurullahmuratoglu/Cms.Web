using Cms.Web.Class;
using Cms.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Cms.Web.Controllers
{
    public class ContactController : Controller
    {
        private AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData.AddAdminLayoutInfo(_context);
            return View();
        }
        [HttpPost]
        [Route("[controller]/[action]")]
        public ActionResult AddContactForm(ContactForm contactForm) 
        {
            if (ModelState.IsValid)
            {
                contactForm.SendDate = DateTime.Now;
                _context.ContactForms.Add(contactForm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        [Route("AdminPanel/ContactForm/")]
        public IActionResult APIndex() 
        {
            var contactform = _context.ContactForms.ToList();
            return View(contactform);
        }
        [Authorize]
        [Route("AdminPanel/ContactForm/{id}")]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Details(int id)
        {
            var contactform = _context.ContactForms.Find(id);
            return View(contactform);
        }
    }
}
