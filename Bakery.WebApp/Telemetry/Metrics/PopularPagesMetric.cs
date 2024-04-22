using System.Diagnostics.Metrics;

namespace Bakery.WebApp.Telemetry;
public class PopularPagesMetric
{
    public Counter<int> AboutPageCounter { get; private set; }
    public Counter<int> CartPageCounter { get; private set; }
    public Counter<int> CheckoutPageCounter { get; private set; }
    public Counter<int> CustomizeItemPageCounter { get; private set; }
    public Counter<int> HomePageCounter { get; private set; }
    public Counter<int> ThankYouPageCounter { get; private set; }
    public Counter<int> MenuContentsCounter { get; private set; }
    public PopularPagesMetric(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MetricName);

        AboutPageCounter = meter.CreateCounter<int>("bakery.about_page_counter");
        CartPageCounter = meter.CreateCounter<int>("bakery.cart_page_counter");
        CheckoutPageCounter = meter.CreateCounter<int>("bakery.checkout_page_counter");
        CustomizeItemPageCounter = meter.CreateCounter<int>("bakery.customize_item_page_counter");
        HomePageCounter = meter.CreateCounter<int>("bakery.home_page_counter");
        ThankYouPageCounter = meter.CreateCounter<int>("bakery.thank_you_page_counter");
        MenuContentsCounter = meter.CreateCounter<int>("bakery.menu_contents_counter");
    }

    public static string MetricName = "bakery.PopularPages";

    public void IncrementPopularPageCounter(string page)
    {
        switch (page)
        {
            case "about":
                AboutPageCounter.Add(1);
                break;
            case "cart":
                CartPageCounter.Add(1);
                break;
            case "checkout":
                CheckoutPageCounter.Add(1);
                break;
            case "customize":
                CustomizeItemPageCounter.Add(1);
                break;
            case "home":
                HomePageCounter.Add(1);
                break;
            case "thankyou":
                ThankYouPageCounter.Add(1);
                break;
            case "menucontents":
                MenuContentsCounter.Add(1);
                break;
            default:
                throw new ArgumentException("Invalid page");
        }
    }


}