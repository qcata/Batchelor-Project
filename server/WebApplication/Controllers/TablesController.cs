using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class TablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetTables(int restaurantId)
        {

            var tables = _context.Tables.ToList();
            var model = TableMapper.GetTableModelFrom(tables);

            return Json(model);
        }
    }
}
