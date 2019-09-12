using System.Linq;
using System.Net;
using System.Net.Mail;
using WebApplication.Constants;
using WebApplication.Data;

namespace WebApplication.Helpers
{
    public class SmtpHelper
    {
        public static void SendEmail(Appointments appointment, ApplicationDbContext context)
        {

            var restaurantEmailAddressSetting = context.RestaurantSettings.Where(rs => rs.parameter == RestaurantParameters.RestaurantEmailAddress)
                                                                          .FirstOrDefault();
            string restaurantEmailAddress = restaurantEmailAddressSetting != null ? restaurantEmailAddressSetting.parameterValue :
                                                                                    RestaurantParameters.RestaurantEmailAddressDefault;

            var restaurantNameSetting = context.RestaurantSettings.Where(rs => rs.parameter == RestaurantParameters.RestaurantName)
                                                                          .FirstOrDefault();
            string restaurantName = restaurantNameSetting != null ? restaurantNameSetting.parameterValue :
                                                                                    RestaurantParameters.RestaurantNameDefault;

            var restaurantEmailPasswordSetting = context.RestaurantSettings.Where(rs => rs.parameter == RestaurantParameters.RestaurantEmailPassword)
                                                                          .FirstOrDefault();
            string restaurantEmailPassword = restaurantEmailPasswordSetting != null ? restaurantEmailPasswordSetting.parameterValue :
                                                                                    RestaurantParameters.RestaurantEmailPasswordDefault;

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(appointment.persEmail, appointment.persName));
                message.From = new MailAddress(restaurantEmailAddress, $"From {restaurantName}");
                message.Subject = "Reservation details";
                message.Body = $"Please present the following reservation number at the arrival to restaurant: {appointment.Id}. \n" +
                               $"Your reservation details: \n" +
                               $"Start Time: {appointment.startTime} \n" +
                               $"End Time: {appointment.endTime} \n" +
                               $"Name: {appointment.persName} \n" +
                               $"Phone: {appointment.persPhone} \n" +
                               $"Number of people: {appointment.pplCount}";
                //message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(restaurantEmailAddress, restaurantEmailPassword);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}
