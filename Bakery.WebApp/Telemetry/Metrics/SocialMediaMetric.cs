using System.Diagnostics.Metrics;

namespace Bakery.WebApp.Telemetry;
public class SocialMediaMetric
{
    public Counter<int> FacebookCounter { get; private set; }
    public Counter<int> TwitterCounter { get; private set; }
    public Counter<int> InstagramCounter { get; private set; }
    public Counter<int> LinkedinCounter { get; private set; }
    public SocialMediaMetric(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MetricName);

        FacebookCounter = meter.CreateCounter<int>("bakery.facebook_counter");
        TwitterCounter = meter.CreateCounter<int>("bakery.twitter_counter");
        InstagramCounter = meter.CreateCounter<int>("bakery.instagram_counter");
        LinkedinCounter = meter.CreateCounter<int>("bakery.linkedin_counter");
    }

    public static string MetricName = "bakery.SocialMedia";

    public void IncrementSocialMediaCounter(string social_network)
    {
        Console.WriteLine("click added");
        switch (social_network)
        {
            case "facebook":
                FacebookCounter.Add(1);
                break;
            case "twitter":
                TwitterCounter.Add(1);
                break;
            case "instagram":
                InstagramCounter.Add(1);
                break;
            case "linkedin":
                LinkedinCounter.Add(1);
                break;
            default:
                throw new ArgumentException("Invalid social network");
        }
    }


}