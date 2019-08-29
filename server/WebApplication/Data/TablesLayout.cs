using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class TablesLayout
    {
        [Key]
        public int Id { get; set; }

        public int localTableId { get; set; }

        public Restaurant restaurantId { get; set; }

        public bool hidden { get; set; }

        public bool pinned { get; set; }

        public float position_x { get; set; }

        public float position_y { get; set; }

        public float position_w { get; set; }

        public float position_h { get; set; }

        public int maxPeople { get; set; }

    }
}
