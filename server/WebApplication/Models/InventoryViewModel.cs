using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class InventoryViewModel
    {
        public string ItemName { get; set; }

        public int ItemCount { get; set; }

        public bool IsVisible { get; set; }

        public double ItemPrice { get; set; }
    }
}
