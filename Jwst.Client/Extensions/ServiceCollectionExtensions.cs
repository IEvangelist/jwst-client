// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all of the required services for the generated <see cref="IJamesWebbClient"/> implementation
    /// to be resolvable via dependency injection.
    /// </summary>
    /// <param name="services">The service collection to add the required services to.</param>
    /// <param name="configuration">The configuration in which </param>
    /// <returns>The same <paramref name="services"/> instance passed in, but with the added services.</returns>
    public static IServiceCollection AddJamesWebbClientServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JamesWebbApiSettings>(
            config: configuration.GetSection(key: JamesWebbApiSettings.SectionName));

        services.AddSingleton<IValidateOptions<JamesWebbApiSettings>, JamesWebbApiSettings>();

        services.AddRedaction();

        services.AddLatencyContext();

        services.AddDefaultHttpClientLatencyTelemetry();

        services.AddHttpClient(
            name: nameof(IJamesWebbClient),
            configureClient: static (services, client) =>
            {
                client.BaseAddress = new("https://api.jwstapi.com");

                IOptions<JamesWebbApiSettings> options =
                    services.GetRequiredService<IOptions<JamesWebbApiSettings>>();

                client.DefaultRequestHeaders.Add("X-API-KEY", options.Value.Key);
            })
            .AddHttpClientMetering()    // Meter overall request
            .AddHttpClientLogging()     // Log overall attempt
            .AddStandardResilienceHandler();

        services.AddJamesWebbClient(
            configureOptions: static options =>
            options.JsonSerializerOptions = new(JsonSerializerDefaults.Web)
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = SnakeOrCamelCaseNamingPolicy.Instance
            });

        return services;
    }
}
