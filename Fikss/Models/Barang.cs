using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fikss.Models
{
    public class Barang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public int Harga { get; set; }
        public int Stock { get; set; }

        /*public Role role { get; set; }*/
    }
}
