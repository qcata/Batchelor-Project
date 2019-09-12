using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WebApplication.Helpers
{
    public class TwilloCommunication 
    {
        public static bool SendMessageToClient(string phoneNumber)
        {
            const string accountSid = "ACb2aea82e9a7fb8a92ad0a19f02e90aee";
            const string authToken = "073606ade348cdbc2f35b0364515d659";

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