using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GHW_Twilio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public TwilioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET api/<TwilioController>
        [HttpGet]
        public IActionResult Get(string phoneNumber)
        {
            var accountSID = Configuration["TwilioAccountSID"];
            var authToken = Configuration["TwilioAuthToken"];
            var twilioPhoneNumber = Configuration["TwilioPhoneNumber"];

            TwilioClient.Init(accountSID, authToken);
            /*
            var message = MessageResource.Create(
                body: "Hi from Global Hack Week: Share!\n\nHope you're keeping well",
                to: new Twilio.Types.PhoneNumber(phoneNumber),
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber)
                );
            */

            var call = CallResource.Create(
                to: new Twilio.Types.PhoneNumber(phoneNumber),
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                twiml: new Twilio.Types.Twiml("<Response><Play>https://demo.twilio.com/docs/classic.mp3</Play></Response>")
                );

            return Ok(call);
        }
    }
}
