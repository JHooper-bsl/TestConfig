using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TestConfig.Controllers;

[ApiController]
[Route("[controller]")]
public class SubsController(IOptions<SubscriptionTiers> opts) : ControllerBase
{
    [HttpGet]
    public SubscriptionTiers Get()
    {
        return opts.Value;
    }
}
