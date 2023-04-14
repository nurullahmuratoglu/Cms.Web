using AutoMapper;
using Cms.Web.Class;
using Cms.Web.Models;
using Cms.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Cms.Web.Controllers
{
    public class BlogController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;


        public BlogController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }

        [Authorize]
        [Route("/AdminPanel/Blog")]
        [Route("/AdminPanel/Blogs")]
        public IActionResult APIndex()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }
        [Authorize]
        [Route("/AdminPanel/Blog/{id}")]
        public IActionResult Details(int id)
        {
            var blogs = _context.Blogs.Find(id);
            return View(_mapper.Map<BlogViewModel>(blogs));

        }
        [Authorize]
        [Route("/AdminPanel/DeleteBlog/{id}")]
        public IActionResult Delete(int id)
        {
            var blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("APIndex");
        }
        
        [HttpGet]
        [Authorize]
        [Route("/AdminPanel/AddBlog")]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        [Route("/AdminPanel/AddBlog")]
        public IActionResult Add(BlogViewModel newblog)
        {
            newblog.Sendtime = DateTime.Now;
            if (ModelState.IsValid)
            {
                var blog = _mapper.Map<Blog>(newblog);
                if (newblog.Image != null && newblog.Image.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot");

                    var images = root.First(x => x.Name == "images");


                    var randomImageName = Guid.NewGuid() + Path.GetExtension(newblog.Image.FileName);


                    var path = Path.Combine(images.PhysicalPath, randomImageName);


                    using var stream = new FileStream(path, FileMode.Create);


                    newblog.Image.CopyTo(stream);

                    blog.ImagePath = randomImageName;
                }
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("APIndex");

            }
            return View();
        }
        [Route("Blog")]
        [Route("Blogs")]
        public IActionResult WebSiteIndex()
        {

            
            ViewData.AddAdminLayoutInfo(_context);

            var blogs = _context.Blogs.ToList();

            return View(blogs);

        }
        [Route("Blog/Detail")]
        [Route("Blogs/Details")]
        public IActionResult WebSiteDetail(int id)
        {
            ViewData.AddAdminLayoutInfo(_context);

            var blog = _context.Blogs.Find(id);
            var viewmodelblog = _mapper.Map<BlogViewModel>(blog);
            viewmodelblog.Comments = _context.Comments.Where(x => x.BlogId == id).ToList();

            return View(viewmodelblog);

        }


    }
}
