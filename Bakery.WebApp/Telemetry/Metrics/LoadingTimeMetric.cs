using System.Diagnostics.Metrics;

namespace Bakery.WebApp.Telemetry;
class LoadingTimeMetric
{
    public Histogram<double> AboutPage_ProcessingTime { get; private set; }
    public Histogram<double> CartPage_ProcessingTime { get; private set; }
    public Histogram<double> CheckoutPage_ProcessingTime { get; private set; }
    public Histogram<double> CustomizeItemPage_ProcessingTime { get; private set; }
    public Histogram<double> HomePage_ProcessingTime { get; private set; }
    public Histogram<double> ThankYouPage_ProcessingTime { get; private set; }
    public Histogram<double> MenuContents_ProcessingTime { get; private set; }
    public LoadingTimeMetric(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MetricName);

        AboutPage_ProcessingTime = meter.CreateHistogram<double>("bakery.about_page_processing_time");
        CartPage_ProcessingTime = meter.CreateHistogram<double>("bakery.cart_page_processing_time");
        CheckoutPage_ProcessingTime = meter.CreateHistogram<double>("bakery.checkout_page_processing_time");
        CustomizeItemPage_ProcessingTime = meter.CreateHistogram<double>("bakery.customize_item_page_processing_time");
        HomePage_ProcessingTime = meter.CreateHistogram<double>("bakery.home_page_processing_time");
        ThankYouPage_ProcessingTime = meter.CreateHistogram<double>("bakery.thank_you_page_processing_time");
        MenuContents_ProcessingTime = meter.CreateHistogram<double>("bakery.menu_contents_processing_time");
    }
    public static string MetricName = "bakery.ProcessingTime";

    public void RecordTimeForPage(string page, double time)
    {
        switch (page)
        {
            case "about":
                AboutPage_ProcessingTime.Record(time);
                break;
            case "cart":
                CartPage_ProcessingTime.Record(time);
                break;
            case "checkout":
                CheckoutPage_ProcessingTime.Record(time);
                break;
            case "customize":
                CustomizeItemPage_ProcessingTime.Record(time);
                break;
            case "home":
                HomePage_ProcessingTime.Record(time);
                break;
            case "thankyou":
                ThankYouPage_ProcessingTime.Record(time);
                break;
            case "menucontents":
                MenuContents_ProcessingTime.Record(time);
                break;
            default:
                throw new ArgumentException("Invalid page");
        }
    }
}