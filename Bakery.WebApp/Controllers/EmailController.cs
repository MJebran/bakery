using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailSender;
        public EmailController(IEmailService emailSender)
        {
            this.emailSender = emailSender;
        }
        [HttpPost("postemail")]
        public async Task SendEmail(string receiverEmail, string identifier, List<Itempurchase>? itempurchases)
        {
            await emailSender.SendEmailAsync(receiverEmail, identifier, itempurchases);
        }
    }
}
