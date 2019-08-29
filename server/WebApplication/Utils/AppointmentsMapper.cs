using System;
using System.Collections.Generic;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Utils
{
    public class AppointmentsMapper
    {
        public static IList<AppointmentsViewModel> GetAppointmentsModelFrom(IList<Appointments> appointments)
        {
            var returnedList = new List<AppointmentsViewModel>();
            foreach (var appointment in appointments)
            {
                returnedList.Add(new AppointmentsViewModel
                {
                    date = appointment.startTime.ToShortDateString(),
                    startTime = $"{appointment.startTime.Hour}:{appointment.startTime.Minute}",
                    endTime = $"{appointment.endTime.Hour}:{appointment.endTime.Minute}"
                });
            }
            return returnedList;
        }

        public static Appointments GetAppointmentFrom(EventViewModel eventModel)
        {
            var ts = TimeSpan.Parse(eventModel.startTime);
            var tempStartTime = new DateTime(eventModel.date.Year, eventModel.date.Month, eventModel.date.Day, ts.Hours, ts.Minutes, 0);


            ts = TimeSpan.Parse(eventModel.endTime);
            var tempEndTime = new DateTime(eventModel.date.Year, eventModel.date.Month, eventModel.date.Day, ts.Hours, ts.Minutes, 0);

            return new Appointments()
            {
                persName = eventModel.Name,
                persPhone = eventModel.Phone,
                pplCount = 1,
                restaurant = eventModel.restaurant,
                startTime = tempStartTime,
                endTime = tempEndTime,
                table = eventModel.table
            };
        }
    }
}
