using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public Restaurant restaurant { get; set; }

        public string itemName { get; set; }

        public int itemCount { get; set; }

        public bool isVisible { get; set; }

        public double itemPrice { get; set; }
    }
}
