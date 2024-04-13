using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Bakery.WebApp.Logic;
using MailKit.Net.Smtp;
using MimeKit;
using static Bakery.WebApp.Logic.CheckoutBase;

namespace Bakery.WebApp.Services
{
    public class EmailService(IConfiguration config) : IEmailService
    {

        public async Task SendEmailAsync(string ReceiverEmail, string identifier, List<Itempurchase>? itempurchases)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auto Emailer", config["googleAccount"]));
            message.To.Add(new MailboxAddress("An Email in need of a Message", ReceiverEmail));
            message.Subject = "Automated Message System";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<html>
        <body>
            <p>Thank you for your Purchase</p>
            <p>Please find below your Payment Summary:</p>
            <table class='table'>
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Quantity</th>
                        <th>Topping Name</th>
                        <th>Topping Quantity</th>
                        <th>Topping Unit Price</th>
                        <th>Topping Total</th>
                        <th>Base Price</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>";

            // Iterar sobre la lista de itempurchases para agregar cada uno como una fila de la tabla
            foreach (var item in itempurchases)
            {
                bodyBuilder.HtmlBody += $@"
        <tr>
            <td>{item.ItempurchaseQuantity} x {item.ItempurchaseItem.Item.ItemName}</td>
            <td>{item.ItempurchaseQuantity}</td>
            <td>";

                foreach (var customTopping in item.ItempurchaseItem.Customitemtoppings)
                {
                    bodyBuilder.HtmlBody += $@"<div>{customTopping.Topping.ToppingName}</div>";
                }

                bodyBuilder.HtmlBody += $@"</td>
            <td>";

                foreach (var customTopping in item.ItempurchaseItem.Customitemtoppings)
                {
                    bodyBuilder.HtmlBody += $@"<div>{customTopping.CustomItemToppingQuantity}</div>";
                }

                bodyBuilder.HtmlBody += $@"</td>
            <td>";

                foreach (var customTopping in item.ItempurchaseItem.Customitemtoppings)
                {
                    bodyBuilder.HtmlBody += $@"<div>{customTopping.Topping.ToppingPrice}</div>";
                }

                bodyBuilder.HtmlBody += $@"</td>
            <td>";

                decimal totalToppingsPrice = item.ItempurchaseItem.Customitemtoppings.Sum(customTopping => customTopping.Topping.ToppingPrice * customTopping.CustomItemToppingQuantity) ?? 0;
                bodyBuilder.HtmlBody += totalToppingsPrice.ToString("C");

                bodyBuilder.HtmlBody += $@"</td>
            <td>";

                decimal basePrice = item.ItempurchaseItem.Item.ItemPrice ?? 0;
                bodyBuilder.HtmlBody += basePrice.ToString("C");

                bodyBuilder.HtmlBody += $@"</td>
            <td>";

                decimal totalPrice = (item.ItempurchaseQuantity * item.ItempurchaseItem.Item.ItemPrice) + totalToppingsPrice ?? 0;
                bodyBuilder.HtmlBody += totalPrice.ToString("C");

                bodyBuilder.HtmlBody += $@"</td>
        </tr>";
            }

            bodyBuilder.HtmlBody += $@"</tbody>
            </table>
            <p>-- TicketUR</p>
        </body>
    </html>";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(config["googleAccount"], config["googlePassword"]);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
