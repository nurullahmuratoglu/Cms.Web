using AutoMapper;
using Cms.Web.Models;
using Cms.Web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Controllers
{
    [Route("/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel users)
        {
            var uservalue = _context.Users.FirstOrDefault(x => x.Email == users.Email && x.Password == users.Password);
            if (uservalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,users.Email)

                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");

            }

            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel Newuser)
        {


            if (ModelState.IsValid)
            {
                var anyProduct = _context.Users.Any(x => x.Email.ToLower() == Newuser.Email.ToLower());
                if (anyProduct)
                {
                    ModelState.AddModelError("Email", "Bu Email Kayıtlı");
                    return View();
                }
                var users = _mapper.Map<User>(Newuser);
                _context.Users.Add(users);
                _context.SaveChanges();
                //TempData["status"] = "kayıt işlemi başarılı bir şekilde gerçeklişti lütfen giriş yapınız";
                return RedirectToAction("Login");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            

            return RedirectToAction("Index","Home");

        }

        //public IActionResult HasUserEmail(string email)
        //{
        //    var anyProduct = _context.Users.Any(x => x.Email.ToLower() == email.ToLower());
        //    if (anyProduct)
        //    {
        //        return Json("Bu Email kayıtlı lütfen giriş yapınız.");
        //    }
        //    else
        //    {
        //        return Json(true);

        //    }

        //}
    }
}
