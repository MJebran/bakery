using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receiverEmail, List<Itempurchase>? itempurchases);
    }
}
