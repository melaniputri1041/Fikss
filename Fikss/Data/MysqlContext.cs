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
    }
}
