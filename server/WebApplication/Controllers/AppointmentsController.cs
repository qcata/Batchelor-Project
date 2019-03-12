using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class AppointmentsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAppointments(int restaurantId)
        {

            var appointments = _context.Tables.ToList();
            return null;
        }
    }
}
