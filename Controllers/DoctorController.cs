using AutoMapper;
using Cms.Web.Models;
using Cms.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;
using Cms.Web.Class;

namespace Cms.Web.Controllers
{
    public class DoctorController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public DoctorController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }
        [Authorize]
        [Route("AdminPanel/Doctor")]
        public IActionResult ApIndex()
        {


            List<DoctorViewModel> doctors = _context.Doctors.Include(x => x.Policlinic).Select(x => new DoctorViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                title = x.title,
                PoliclinicName = x.Policlinic.Name,
                ImagePath = x.ImagePath
            }).ToList();
            return View(doctors);

            //var doctors = _context.Doctors.ToList();
            //return View(_mapper.Map<DoctorViewModel>(doctors));
        }
        [HttpGet]
        [Authorize]
        [Route("AdminPanel/AddDoctor")]
        public IActionResult Add()
        {
            var policlinic = _context.Policlinics.ToList();
            ViewBag.policlinicselect = new SelectList(policlinic, "Id", "Name");

            return View();

        }
        [HttpPost]
        [Authorize]
        [Route("AdminPanel/AddDoctor")]

        public IActionResult Add(DoctorViewModel newdoctor)
        {
            if (ModelState.IsValid)
            {

                Doctor doctors = new Doctor();
                doctors.Id = newdoctor.Id;
                doctors.FullName = newdoctor.FullName;
                doctors.title = newdoctor.title;
                doctors.PoliclinicId = newdoctor.PoliclinicId;
                
                if (newdoctor.Image != null && newdoctor.Image.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot").ToList();

                    var images = root.First(x => x.Name == "images");


                    var randomImageName = Guid.NewGuid() + Path.GetExtension(newdoctor.Image.FileName);


                    var path = Path.Combine(images.PhysicalPath, randomImageName);


                    using var stream = new FileStream(path, FileMode.Create);


                    newdoctor.Image.CopyTo(stream);

                    doctors.ImagePath = randomImageName;
                }

                _context.Doctors.Add(doctors);
                _context.SaveChanges();
                return RedirectToAction("APIndex");

            }
            return View();

        }
        [Authorize]
        [Route("AdminPanel/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            _context.Doctors.Remove(_mapper.Map<Doctor>(doctor));
            _context.SaveChanges();
            return RedirectToAction("APIndex");

        }
        [Route("Doctor")]
        [Route("Doctors")]
        public IActionResult WebSiteIndex() 
        {
            ViewData.AddAdminLayoutInfo(_context);
            List<DoctorViewModel> doctors = _context.Doctors.Include(x => x.Policlinic).Select(x => new DoctorViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                title = x.title,
                PoliclinicName = x.Policlinic.Name,
                ImagePath = x.ImagePath
            }).ToList();
            return View(doctors);


        }
    }
}