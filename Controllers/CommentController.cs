using AutoMapper;
using Cms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Cms.Web.Controllers
{
    public class CommentController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public CommentController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Comment comment, int id)
        {

            comment.BlogId = id;
            comment.Created = DateTime.Now;
            comment.Id = 0;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("WebSiteDetail", "Blog", new { id=comment.BlogId });

        }
    }
}
