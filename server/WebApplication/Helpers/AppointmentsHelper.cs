using System.Collections.Generic;
using System.Linq;
using WebApplication.Constants;
using WebApplication.Data;

namespace WebApplication.Helpers
{
    public class AppointmentsHelper
    {
        internal static bool CheckForOverlappingAppointments(Appointments appointment, ApplicationDbContext context)
        {
            var overlappingAppointments = context.Appointments.Where(a => a.restaurant == appointment.restaurant &&
                                                                          a.table == appointment.table &&
                                                                          (a.startTime >= appointment.startTime && a.startTime <= appointment.endTime) ||
                                                                          (a.endTime >= appointment.startTime && a.endTime <= appointment.endTime)).ToList();
            return overlappingAppointments.Any();
        }

        internal static double ComputeAppointmentAmount(Appointments appointment, ApplicationDbContext context)
        {
            var restaurantBaseReservationAmount = context.RestaurantSettings.Where(rs => rs.parameter == RestaurantParameters.RestaurantBaseReservationAmount).FirstOrDefault();
            double baseAmount;
            int percentageToAmount = 0;
            if (restaurantBaseReservationAmount == null)
            {
                baseAmount = RestaurantParameters.RestaurantBaseReservationAmountDefault;
            }
            else
            {
                if (!double.TryParse(restaurantBaseReservationAmount.parameterValue, out baseAmount))
                {
                    baseAmount = RestaurantParameters.RestaurantBaseReservationAmountDefault;
                }
            }

            //check if rushHour
            if (appointment.startTime.Hour > 6 && appointment.startTime.Hour < 10)
            {
                if (appointment.endTime.Hour > 6 && appointment.endTime.Hour < 10)
                {
                    percentageToAmount += 15;
                }
                else
                {
                    percentageToAmount += 10;
                }
            }
            else if (appointment.startTime.Hour > 16 && appointment.startTime.Hour < 20)
            {
                if (appointment.endTime.Hour > 16 && appointment.endTime.Hour < 20)
                {
                    percentageToAmount += 15;
                }
                else
                {
                    percentageToAmount += 10;
                }
            }

            // check if weekend

            if (appointment.startTime.DayOfWeek == System.DayOfWeek.Saturday || appointment.startTime.DayOfWeek == System.DayOfWeek.Sunday)
            {
                percentageToAmount += 15;
            }

            // check if there are less ppl
            if (appointment.pplCount < 5)
            {
                percentageToAmount += 5;
            }

            //check for past appointments
            List<Appointments> pastAppointments = new List<Appointments>();
            if (!string.IsNullOrEmpty(appointment.persEmail))
            {
                pastAppointments = context.Appointments.Where(a => a.startTime < appointment.startTime &&
                                                                  (a.persEmail == appointment.persEmail ||
                                                                   a.persPhone == appointment.persPhone)).ToList();
            }
            else
            {
                pastAppointments = context.Appointments.Where(a => a.startTime < appointment.startTime &&
                                                                   a.persPhone == appointment.persPhone).ToList();
            }
            if (pastAppointments.Count > 0)
            {
                if (pastAppointments.Count(pa => pa.hasBeenHonored == false) > pastAppointments.Count / 2)
                {
                    percentageToAmount += 35;
                }
                else if (pastAppointments.Count(pa => pa.hasBeenHonored == false) == pastAppointments.Count)
                {
                    return -1;
                }
                else
                {
                    percentageToAmount += 10;
                }
            }

            return baseAmount + (baseAmount * percentageToAmount / 100);
        }
    }
}

