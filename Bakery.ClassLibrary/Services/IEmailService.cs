using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receiverEmail, string identifier, List<Itempurchase>? itempurchases);
    }
}
