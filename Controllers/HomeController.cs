using AutoMapper;
using Cms.Web.Class;
using Cms.Web.Models;
using Cms.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Cms.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [Route("")]

        public IActionResult Index()
        {
            ViewData.AddAdminLayoutInfo(_context);
            var homepage = _context.HomePages.FirstOrDefault(x => x.Id == 1);
            var homepageviewmodel = _mapper.Map<HomePageViewModel>(homepage);
            homepageviewmodel.Referanss = _context.Referanss.ToList();
            return View(homepageviewmodel);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.url= exception.Path;
            ViewBag.message = exception.Error.Message;

            return View();
        }
        [Route("/AdminPanel/[action]")]
        [Route("/AdminPanel")]
        [Authorize]
        [HttpGet]
        public IActionResult UpdateHomePage()
        {
            var article = _context.HomePages.FirstOrDefault(x => x.Id == 1);
            return View(article);

        }
        [HttpPost]
        public IActionResult UpdateHomePage(HomePage homePage)
        {
            _context.HomePages.Update(homePage);
            _context.SaveChanges();
            return RedirectToAction("UpdateHomePage");
        }
    }
}