using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConfig.Controllers;

[ApiController]
[Route("[controller]")]
public class SubsController(IOptions<AppSettings> opts) : ControllerBase
{
    private readonly SubscriptionTier[] _subscriptionTiers = opts.Value.SubscriptionTiers;

    [HttpGet]
    public SubscriptionTier[] Get()
    {
        TestInjectedData();
        return _subscriptionTiers;
    }

    private void TestInjectedData()
    {
        var free = _subscriptionTiers.First(x => x.Tier == "Free");

        // This is failing when it should only have 1 empty string
        Assert.AreEqual(1, free.ActiveModules.Count());
        Assert.AreEqual(0, free.ActiveModules.Where(x => !string.IsNullOrWhiteSpace(x)).Count());

        var other = _subscriptionTiers.First(x => x.Tier == "Growth");
        // Again this is failing when there are only 2 values configured
        Assert.AreEqual(2, other.ActiveModules.Count());
    }
}
