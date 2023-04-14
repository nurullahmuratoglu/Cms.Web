using Cms.Web.Class;
using Cms.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Controllers
{

    public class PoliclinicController : Controller
    {
        private AppDbContext _context;

        public PoliclinicController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [Route("AdminPanel/Policlinic")]
        public IActionResult APIndex()
        {
            var policilinic = _context.Policlinics.ToList();
            return View(policilinic);
        }
        [HttpGet]
        [Authorize]
        [Route("AdminPanel/AddPoliclinic")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("AdminPanel/AddPoliclinic")]
        public IActionResult Add(Policlinic policlinic)
        {
            if (ModelState.IsValid)
            {
                _context.Policlinics.Add(policlinic);
                _context.SaveChanges();
                return RedirectToAction("APIndex");

            }
            return View();
        }
        [Authorize]
        [Route("DeletePoliclinic/{id}")]
        public IActionResult Delete(int id)
        {
            var policlinic = _context.Policlinics.Find(id);
            _context.Policlinics.Remove(policlinic);
            _context.SaveChanges();
            return RedirectToAction("APIndex");
        }

        [HttpGet]
        [Authorize]
        [Route("UpdatePoliclinic/{id}")]
        public IActionResult Update(int id)
        {
            var policlinic = _context.Policlinics.Find(id);
            return View(policlinic);

        }
        [HttpPost]
        [Route("UpdatePoliclinic/{id}")]
        public IActionResult Update(Policlinic policlinic)
        {
            if (ModelState.IsValid)
            {
                _context.Policlinics.Update(policlinic);
                _context.SaveChanges();
                return RedirectToAction("APIndex");
            }
            return View();
        }
        [Route("Policlinic")]
        [Route("Policlinics")]
        public IActionResult WebSiteIndex() 
        {
            ViewData.AddAdminLayoutInfo(_context);
            var policlinic = _context.Policlinics.ToList();
            return View(policlinic);
        
        }
        [Route("Policlinic/Details/{id}")]
        [Route("Policlinic/Detail/{id}")]
        public IActionResult Details(int id)
        {
            ViewData.AddAdminLayoutInfo(_context);
            var policlinic = _context.Policlinics.Find(id);
            return View(policlinic);
        }

    }
}
