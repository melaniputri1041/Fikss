using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fikss.Models
{
	public class Pesanan
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Photo { get; set; }
		public int Harga { get; set; }
		public Barang Barang { get; set; }
		public string NamaLengkap { get; set; }
		public string Alamat { get; set; }
		public string NoTelepon { get; set; }
		public Status Status { get; set; }
	}
}
