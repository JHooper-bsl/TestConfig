using System.ComponentModel.DataAnnotations;

namespace TestConfig;

public class AppSettings
{
    public const string SectionName = "AppSettings";

    public SubscriptionTier[] SubscriptionTiers { get; set; } = [];
}

public class SubscriptionTier
{
    public const string SectionName = "SubscriptionTiers";
    
    [Required]
    public string Tier { get; set; } = string.Empty;

    public List<string> ActiveModules { get; set; } = new();
}
