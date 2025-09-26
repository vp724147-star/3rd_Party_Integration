using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Twilio_SMS_Integration.Services
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public TwilioService(IConfiguration config)
        {
            _accountSid = config["Twilio__AccountSid"];
            _authToken = config["Twilio__AuthToken"];
            _fromNumber = config["Twilio__FromNumber"];
        }

        public void SendSms(string to, string body)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(_fromNumber),
                to: new Twilio.Types.PhoneNumber(to)
            );
        }
    }
}
