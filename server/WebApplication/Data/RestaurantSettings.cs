using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class RestaurantSettings
    {
        [Key]
        public int Id { get; set; }

        public Restaurant restaurant { get; set; }

        public string parameter { get; set; }

        public string parameterValue { get; set; }

        public string description { get; set; }
    }
}