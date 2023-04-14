using AutoMapper;
using Cms.Web.Models;
using Cms.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Cms.Web.Controllers
{
    public class ReferansController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        public ReferansController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }
        [Authorize]
        [Route("AdminPanel/Referans")]
        public IActionResult ApIndex()
        {
            var article = _context.Referanss.ToList();
            return View(article);
        }
        [Authorize]
        [HttpGet]
        [Route("AdminPanel/AddReferans")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("AdminPanel/AddReferans")]
        public IActionResult Add(ReferansViewModel newreferans)
        {
            if (ModelState.IsValid)
            {

                var referans = _mapper.Map<Referans>(newreferans);
                if (newreferans.Image != null && newreferans.Image.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot");

                    var images = root.First(x => x.Name == "images");


                    var randomImageName = Guid.NewGuid() + Path.GetExtension(newreferans.Image.FileName);


                    var path = Path.Combine(images.PhysicalPath, randomImageName);


                    using var stream = new FileStream(path, FileMode.Create);


                    newreferans.Image.CopyTo(stream);

                    referans.ImagePath = randomImageName;
                }
                _context.Referanss.Add(referans);
                _context.SaveChanges();
                return RedirectToAction("ApIndex");


            }
            return View();
        }
        [Authorize]
        [Route("AdminPanel/DeleteReferans{id}")]
        public IActionResult Delete(int id) 
        {
            var article = _context.Referanss.Find(id);
            _context.Referanss.Remove(article);
            _context.SaveChanges();

            return RedirectToAction("APIndex");
        
        
        }
    }
}
