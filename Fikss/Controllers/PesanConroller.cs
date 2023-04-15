using Fikss.Models.ViewModels;
using Fikss.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fikss.Data;

namespace Fikss.Controllers
{
	public class PesanConroller
	{
		private readonly MysqlContext _context;
		private readonly IWebHostEnvironment _env;
		/*public IActionResult Pesan(int id)
        {
            var barang = _context.Barangs.FirstOrDefault(x => x.Id == id);

            return View(barang);
        }
        [HttpPost]
        public IActionResult Pesan([FromForm] Barang data)
        {
            _context.Barangs.Add(data);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }*/

		/*public IActionResult Index()
		{
			var users = _context.Barangs.ToList();
			return View(users);
		}
		public PesanConroller(MysqlContext c, IWebHostEnvironment env)
		{
			_context = c;
			_env = env;
		}
		public IActionResult Pesan()
		{
			*//*var barang = _context.Barangs.FirstOrDefault(x => x.Id == id);*/
			/*   var pesan = _context.Pesanans
				  .Include(x => x.Barang)
				  .ToList();*//*

			ViewBag.Barangs = _context.Barangs.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name
			});

			return View();
		}

		[HttpPost]
		public IActionResult Pesan([FromForm] PesananForm data, IFormFile photo)
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
