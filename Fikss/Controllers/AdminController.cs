using Fikss.Data;
using Fikss.Models;
using Microsoft.AspNetCore.Mvc;
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

/*		public async Task<IActionResult> PesananMasuk()
		{
			var users = await _context.Pesanans.ToListAsync();
			return View(users);
		}*/

		[HttpGet]
		public async Task<IActionResult> PesananMasuk(string search)
		{
			var users = await _context.Pesanans.Include(x => x.Barang).ToListAsync();

			if (!String.IsNullOrEmpty(search))
			{
				users = await _context.Pesanans.Include(x => x.Barang).Where(x => x.NamaLengkap.ToLower().Contains(search) || x.NoTelepon.Contains(search)).ToListAsync();
			}

			return View(users);
		}
	}
}
