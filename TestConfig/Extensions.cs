namespace TestConfig;

public static class ServiceCollectionExtensions
{
    public static void AddValidatedOptions<T>(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName) where T : class
    {
        services
            .AddOptions<T>()
            .Bind(configuration.GetSection(sectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}