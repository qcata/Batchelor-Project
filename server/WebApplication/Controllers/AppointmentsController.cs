using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using WebApplication.Data;
using WebApplication.Helpers;
using WebApplication.Models;
using WebApplication.Utils;

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
        public JsonResult GetAppointments(int restaurantId, int tableId)
        {

            var appointments = _context.Appointments.Where(a => a.table.localTableId == tableId
                                                                && a.restaurant.Id == restaurantId
                                                                && a.startTime > DateTime.Now.AddDays(-7)
                                                                && a.startTime < DateTime.Now.AddDays(7)).ToList();

            var model = AppointmentsMapper.GetAppointmentsModelFrom(appointments);

            return Json(model);
        }

        [HttpGet]
        public JsonResult GetAppointmentsForWeek(int restaurantId, int tableId, DateTime newWeek)
        {

            var appointments = _context.Appointments.Where(a => a.table.localTableId == tableId
                                                                && a.restaurant.Id == restaurantId
                                                                && a.startTime > newWeek.AddDays(-7)
                                                                && a.startTime < newWeek.AddDays(7)).ToList();

            var model = AppointmentsMapper.GetAppointmentsModelFrom(appointments);

            return Json(model);
        }


        [HttpGet]
        public JsonResult ValidateAndComputeAppointmentSum(int restaurantId, int tableId, string agendaEvent)
        {
            try
            {
                var appointment = CreateAppointmentFromEvent(restaurantId, tableId, agendaEvent);

                if (!AppointmentsHelper.CheckForOverlappingAppointments(appointment, _context))
                {
                    double totalSumToPay = AppointmentsHelper.ComputeAppointmentAmount(appointment, _context);
                    if (totalSumToPay == -1)
                    {
                        return Json(new { success = false, respose = "You are banned to create appointments due not honoring them. Please contact restaurant management." });
                    }
                    return Json(new { success = true, responseText = totalSumToPay });
                }
                else
                {
                    return Json(new { success = false, responseText = "Overlapping appointments. Please select another time-slot." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex });
            }
        }



        [HttpGet]
        public JsonResult SaveAppointment(int restaurantId, int tableId, string agendaEvent)
        {
            try
            {
                var appointment = CreateAppointmentFromEvent(restaurantId, tableId, agendaEvent);

                if (!AppointmentsHelper.CheckForOverlappingAppointments(appointment, _context))
                {
                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();
                    //TwilloCommunication.SendMessageToClient("");
                    if (!string.IsNullOrEmpty(appointment.persEmail))
                    {
                        SmtpHelper.SendEmail(appointment,_context);
                    }

                    return Json(new { success = true , responseText = appointment.Id });
                }
                else
                {
                    return Json(new { success = false, responseText = "overlapping" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex });
            }

        }


        private Appointments CreateAppointmentFromEvent(int restaurantId, int tableId, string agendaEvent)
        {
            var myEvent = JsonConvert.DeserializeObject<EventViewModel>(agendaEvent);
            myEvent.date = myEvent.date.AddDays(1);
            var restaurant = _context.Restaurants.Where(r => r.Id == restaurantId).FirstOrDefault();

            if (restaurant == null)
            {
                throw new Exception("Invalid restaurant");
            }

            var table = _context.Tables.Where(t => t.localTableId == tableId &&
                                                   t.restaurantId == restaurant).FirstOrDefault();

            if (table == null)
            {
                throw new Exception("Invalid table");
            }
            if (table.maxPeople < myEvent.PplCount)
            {
                throw new Exception("The table you selected is too small.\n Please select a bigger table or contact the restaurant management for special reservations.");
            }

            myEvent.table = table;
            myEvent.restaurant = restaurant;

            var appointment = AppointmentsMapper.GetAppointmentFrom(myEvent);
            return appointment;
        }
    }

}