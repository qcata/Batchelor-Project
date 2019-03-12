namespace WebApplication.Models
{
    public class TableViewModel
    {
        public int id { get; set; }

        public bool hidden { get; set; }

        public bool pinned { get; set; }

        public TablePosition position { get; set; }
    }

}
