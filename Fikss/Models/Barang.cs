using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fikss.Models
{
    public class Barang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string? Photo { get; set; }
		[Required]
		public int Harga { get; set; }



        /*public Role role { get; set; }*/
    }
}
