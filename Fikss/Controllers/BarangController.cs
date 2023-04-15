using Fikss.Data;
using Fikss.Models;
using Fikss.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fikss.Controllers
{
	public class BarangController : Controller
	{
		private readonly MysqlContext _context;
		private readonly IWebHostEnvironment _env;
		public BarangController(MysqlContext c, IWebHostEnvironment env)
		{
			_context = c;
			_env = env;
		}
		public IActionResult Index()
		{
            var users = _context.Barangs.
				ToList();
            return View(users);
        }
		public IActionResult Produk()
		{
			var users = _context.Barangs.ToList();
			return View(users);
		}
        public IActionResult Download(int id)
        {
            var user = _context.Barangs.FirstOrDefault(x => x.Id == id);
            var filepath = Path.Combine(_env.WebRootPath, "upload", user.Photo);

            return File(
                System.IO.File.ReadAllBytes(filepath), "image/png",
                Path.GetFileName(filepath)
                );
        }

        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]

		//IfromFile untuk menambah foto
		public IActionResult Create([FromForm] Barang data, IFormFile Photo)
		{
			 if (Photo.Length > 100000)
			{
				ModelState.AddModelError(nameof(data.Photo), "Photo terlalu besar");
			}
			if (!ModelState.IsValid)
			{
				return View();
			}
			
			var filename = "photo_" + data.Name + Path.GetExtension(Photo.FileName);
			// combine untuk menggambungkan at folder
			var filepath = Path.Combine(_env.WebRootPath,"upload", filename);

			using (var stream = System.IO.File.Create(filepath))
			{
				Photo.CopyTo(stream);
				//proses untuk menyimpan file ke folder
			}

            data.Photo = filename;


            _context.Barangs.Add(data);
			_context.SaveChanges();

			return RedirectToAction("Produk");

		}

		public IActionResult Edit(int id)
		{
			var barang = _context.Barangs.FirstOrDefault(x => x.Id == id);

			return View(barang);
		}

		[HttpPost]

		public IActionResult Edit([FromForm] Barang data)
		{
			_context.Barangs.Update(data);
			_context.SaveChanges();

			return RedirectToAction("produk");
		}

		public IActionResult Delete(int id)
		{
			var barang = _context.Barangs.FirstOrDefault(_x => _x.Id == id);

			_context.Barangs.Remove(barang);
			_context.SaveChanges();

			return RedirectToAction("produk");
		}

	}
}
