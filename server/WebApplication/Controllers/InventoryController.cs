using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAppointments(int restaurantId)
        {

            var inventories = _context.Inventories.Where(i => i.restaurant.Id == restaurantId).ToList();

            var model = InventoryMapper.GetInventoriesModelFrom(inventories);

            return Json(model);
        }
    }
}
