using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult SaveMenuForAppointment(int appointmentId, string menuJson)
        {
            var appointment = _context.Appointments.FirstOrDefault(ap => ap.Id == appointmentId);
            if(appointment == null)
            {
                return Json(new { success = false, responseText = "No appointment available to math the menu" });
            }
            else
            {
                var menu = CreateMenuFromJson(menuJson);
                
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return Json(new { success = true, responseText = menu.Id });
            }
        }

        private Menu CreateMenuFromJson(string menuJson)
        {
            var myMenu = JsonConvert.DeserializeObject<MenuViewModel>(menuJson);

            var menuToSave = new Menu()
            {
                menu = myMenu.Menu,
                totalPrice = myMenu.TotalSum
            };

            return menuToSave;
        }
    }
}
