using System.Collections.Generic;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Utils
{
    public class InventoryMapper
    {
        public static IList<InventoryViewModel> GetInventoriesModelFrom(IList<Inventory> inventories)
        {
            var returnedList = new List<InventoryViewModel>();
            foreach (var inventory in inventories)
            {
                returnedList.Add(new InventoryViewModel
                {
                    IsVisible = inventory.isVisible,
                    ItemCount = inventory.itemCount,
                    ItemName = inventory.itemName,
                    ItemPrice = inventory.itemPrice
                });
            }
            return returnedList;
        }
    }
}
