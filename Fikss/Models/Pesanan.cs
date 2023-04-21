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
		[Required]
		public string NamaLengkap { get; set; }
		[Required]
		public string Alamat { get; set; }
		[Required]
		public string NoTelepon { get; set; }
		[Required]
		public Status Status { get; set; }
	}
}
