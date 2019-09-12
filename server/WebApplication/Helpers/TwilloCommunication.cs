using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WebApplication.Helpers
{
    public class TwilloCommunication 
    {
        public static bool SendMessageToClient(string phoneNumber)
        {
            
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+12563803488"),
                to: new Twilio.Types.PhoneNumber("+40764555005")
            );

            return message != null;
        }
    }
}