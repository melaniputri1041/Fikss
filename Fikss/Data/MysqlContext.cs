 using Fikss.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Fikss.Data
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions options)
           : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Barang> Barangs { get; set; }
        public DbSet<Pesanan> Pesanans { get; set; }

		public DbSet<Status> Status { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// isi tabel roles
			modelBuilder.Entity<Status>().HasData(new Status[]
			{
				new Status
				{
					Id = "1",
					Stat = "Baru"
				},
				new Status
				{
					Id = "2",
					Stat ="Pesanan diterima"
				}
			});
			modelBuilder.Entity<Admin>().HasData(new Admin[]
			{
				new Admin
				{
					Id = "1",
					Username = "melani",
					Password ="1234",
					FullName = "melani putri"
				}
			});
		}
	}
}
