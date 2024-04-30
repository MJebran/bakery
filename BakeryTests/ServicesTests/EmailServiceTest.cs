using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmailServiceTest : IEmailService
{
    public async Task SendEmailAsync(string receiverEmail, List<Itempurchase>? itempurchases)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Auto Emailer", "auto@domain.com")); // Cambia el remitente si es necesario
        message.To.Add(new MailboxAddress("An Email in need of a Message", receiverEmail));
        message.Subject = "Automated Message System";

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = GenerateEmailBodyHtml(itempurchases);

        message.Body = bodyBuilder.ToMessageBody();

        await SimulateEmailSendingAsync(message);
    }

    private string GenerateEmailBodyHtml(List<Itempurchase>? itempurchases)
    {
        return ""; 
    }

    private async Task SimulateEmailSendingAsync(MimeMessage message)
    {
        await Task.Delay(100);
    }
}
