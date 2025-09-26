using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio_SMS_Integration.Models;
using Twilio_SMS_Integration.Services;

namespace Twilio_SMS_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly TwilioService _twilioService;

        public SmsController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        [HttpPost]
        public IActionResult SendSms([FromBody] SmsRequest request)
        {
            try
            {
                _twilioService.SendSms(request.To, request.Body);
                return Ok(new { message = "SMS sent successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
