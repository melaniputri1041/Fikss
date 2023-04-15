 using System.Security.Claims;
using Fikss.Data;
using Fikss.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Fikss.Controllers
{
    public class AccountController : Controller
    {
        private readonly MysqlContext _context;

        public AccountController(MysqlContext c)
        {
            _context = c;
        }
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Login data)
        {
            var user = _context.Admins.Where(x => x.Username == data.username && x.Password == data.password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("username", user.Username),
                    new Claim("name", user.FullName),
                    new Claim("role","admin")
                };

                var identity = new ClaimsIdentity(claims, "Cookie", "name", "role");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/barang/index");
            }

            return View();
        }
    }
}
