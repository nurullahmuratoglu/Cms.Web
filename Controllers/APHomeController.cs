using Cms.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Controllers
{
    [Route("/AdminPanel/[action]")]
    public class APHomeController : Controller
    {
        private AppDbContext _context;

        public APHomeController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public IActionResult UpdateLayout()
        {
            var article= _context.AdminLayouts.FirstOrDefault(x=>x.Id==1);
            return View(article);
        }
        [HttpPost]
        public IActionResult UpdateLayout(AdminLayout UpdateArticle)
        {
            _context.AdminLayouts.Update(UpdateArticle);
            _context.SaveChanges();
            return RedirectToAction("UpdateLayout");
        }

    }
}
