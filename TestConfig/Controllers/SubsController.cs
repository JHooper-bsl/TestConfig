using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConfig.Controllers;

[ApiController]
[Route("[controller]")]
public class SubsController(IOptions<SubscriptionTiers> opts) : ControllerBase
{
    [HttpGet]
    public SubscriptionTiers Get()
    {
        TestInjectedData();
        return opts.Value;
    }

    private void TestInjectedData()
    {
        var free = opts.Value.First(x => x.Tier == "Free");

        // This is failing when it should only have 1 empty string
        Assert.AreEqual(1, free.ActiveModules.Count());
        Assert.AreEqual(0, free.ActiveModules.Where(x => !string.IsNullOrWhiteSpace(x)).Count());

        var other = opts.Value.First(x => x.Tier == "Growth");
        // Again this is failing when there are only 2 values configured
        Assert.AreEqual(2, other.ActiveModules.Count());
    }
}
