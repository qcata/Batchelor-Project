using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }

        public Restaurant restaurant { get; set; }

        public TablesLayout table { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public int pplCount { get; set; }

        public string persName { get; set; }

        public string persPhone { get; set; }
    }
}
