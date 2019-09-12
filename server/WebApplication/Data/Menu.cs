using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string menu { get; set; }
        public double totalPrice { get; set; }
    }
}
