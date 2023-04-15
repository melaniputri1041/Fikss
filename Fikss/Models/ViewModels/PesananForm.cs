namespace Fikss.Models.ViewModels
{
	public class PesananForm
	{
		public int Id { get; set; }

		public string NamaLengkap { get; set; }
		public string Alamat { get; set; }
		public string NoTelepon { get; set; }

		public int barangId { get; set; }
		public string Name { get; set; }
		public string? Photo { get; set; }
		public int Harga { get; set; }

	}
}
