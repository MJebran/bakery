using System.Diagnostics.Metrics;

namespace Bakery.WebApp.Telemetry;
class PurchasesCompletedMetric
{
    public Counter<int> CompletedPurchasesCounter { get; private set; }
    public PurchasesCompletedMetric(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MetricName);

        CompletedPurchasesCounter = meter.CreateCounter<int>("bakery.purchases_completed_counter");
    }
    public static string MetricName = "bakery.CompletedPurchases";
    public void IncrementPopularPageCounter()
    {
        CompletedPurchasesCounter.Add(1);
    }
}