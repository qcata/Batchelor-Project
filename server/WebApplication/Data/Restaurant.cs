using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public string phoneNumber { get; set; }

        public string address { get; set; }

    }
}
