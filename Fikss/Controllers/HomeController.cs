using System.Diagnostics;
using Fikss.Data;
using Fikss.Models;
using Fikss.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fikss.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MysqlContext _context;
		private readonly IWebHostEnvironment _env;

		public HomeController(ILogger<HomeController> logger, MysqlContext c, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = c;
			_env = env;
		}

        public IActionResult Index()
        {
            var users = _context.Barangs.ToList();
            /*   var pesan = _context.Pesanans
                    .Include(x => x.Barang)
                    .ToList();*/
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }
		public IActionResult Tentang()
		{
			return View();
		}
        public IActionResult Awal()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult Pesan(int id)
        {
            ViewBag.Statuses = _context.Status.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Stat
            });

            var barang = _context.Barangs.FirstOrDefault(x => x.Id == id);
            return View(barang);
        }
        
       [HttpPost]
        public IActionResult Pesan([FromForm] PesananForm data, int barangId)
        {
            var barang = _context.Barangs.FirstOrDefault(x => x.Id == barangId);
            var pesanan = new Pesanan()
            {
                Barang = barang,
                Name = data.Name,
                Harga = data.Harga,
                Photo = data.Photo,
                NamaLengkap = data.NamaLengkap,
                Alamat = data.Alamat,
                NoTelepon = data.NoTelepon,
                Status = _context.Status.FirstOrDefault(s => s.Id == 1.ToString())
            };
            _context.Pesanans.Add(pesanan);
            _context.SaveChanges();

            return RedirectToAction(/*"pesananmasuk","admin"*/"index","home");
        }
		/*public IActionResult Pesan()
		{
            *//*var barang = _context.Barangs.FirstOrDefault(x => x.Id == id);*//*

            ViewBag.Barangs = _context.Barangs.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View();
		}*/

		/*[HttpPost]
		public IActionResult Pesan([FromForm] PesananForm data,IFormFile photo)
        {
            if (photo.Length > 100000)
            {
                ModelState.AddModelError(nameof(data.Photo), "Potonya kegedean");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var filename = "photo" + data.NamaLengkap + Path.GetExtension(photo.FileName);

            var filepath = Path.Combine(_env.WebRootPath, filename);

            using (var stream = System.IO.File.Create(filepath))
            {
                photo.CopyTo(stream);
            }
            data.Photo = filename;
            var role = _context.Barangs.FirstOrDefault(x => x.Id == data.barangId);
            var user = new Pesanan()
            {
                Id = data.Id,
                Name = data.Name,
                Photo = filename,
                Harga = data.Harga,
                NamaLengkap = data.NamaLengkap,
                Alamat = data.Alamat,
                NoTelepon = data.NoTelepon,
                Barang = role
            };
            _context.Pesanans.Add(user);
			_context.SaveChanges();

			return Redirect("/admin/PesananMasuk");
		}*/
	}
}