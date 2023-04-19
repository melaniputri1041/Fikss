using Fikss.Data;
using Fikss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fikss.Controllers
{
	
	public class AdminController : Controller
    {
		private readonly MysqlContext _context;
		public AdminController(MysqlContext c)
		{
			_context = c;
		}

		public IActionResult PesananMasuk()
		{
			var pesanan = _context.Pesanans.Include(p => p.Status).ToList();
			return View(pesanan);
		}

		[HttpGet]
		public async Task<IActionResult> PesananMasuk(string search)
		{
			var users = await _context.Pesanans.Include(x => x.Barang)
				.Include(x => x.Status)
				.ToListAsync();

			if (!String.IsNullOrEmpty(search))
			{
				users = await _context.Pesanans.Include(x => x.Barang).Where(x => x.NamaLengkap.ToLower().Contains(search) || x.NoTelepon.Contains(search)).ToListAsync();
			}

			return View(users);
		}
		public IActionResult Edit(int id)
		{
			ViewBag.Status = _context.Status.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Stat
			});

			var share = _context.Pesanans.Include(x => x.Status).FirstOrDefault(x => x.Id == id);
			return View(share);
		}

		[HttpPost]
		public IActionResult Edit([FromForm] Pesanan data, int idStatus)
		{
			data.Status = _context.Status.FirstOrDefault(s => s.Id == idStatus.ToString());
			_context.Pesanans.Update(data);
			_context.SaveChanges();
			return RedirectToAction("PesananMasuk");
		}
	}
}
