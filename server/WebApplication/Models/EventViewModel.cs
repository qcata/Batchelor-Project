using System;
using WebApplication.Data;

namespace WebApplication.Models
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PplCount { get; set; }
        public DateTime date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public Restaurant restaurant { get; set; }
        public TablesLayout table { get; set; }
    }
}
