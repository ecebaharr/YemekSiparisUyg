using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUı.Dtos.IdentityDtos;

namespace SignalRWebUı.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            // ✅ 1. MODELSTATE kontrolü
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var appUser = new AppUser
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (result.Succeeded)
            {
                // ✅ 2. BAŞARILIYSA login sayfasına yönlendir
                return RedirectToAction("Index", "Login");
            }

            // ✅ 3. HATA VARSA modelstate'e ekle
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(registerDto);
        }
    }
}
