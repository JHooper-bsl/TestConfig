using System.ComponentModel.DataAnnotations;

namespace TestConfig;

public class SubscriptionTiers : List<SubscriptionTier>
{
    public const string SectionName = "SubscriptionTiers";
}

public record SubscriptionTier([Required] string Tier, IEnumerable<string> ActiveModules);
