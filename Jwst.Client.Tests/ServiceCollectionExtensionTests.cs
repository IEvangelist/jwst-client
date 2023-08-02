// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Tests;

public class ServiceCollectionExtensionTests
{
    private readonly ITestOutputHelper _output;

    public ServiceCollectionExtensionTests(ITestOutputHelper output) => _output = output;

    [Fact]

    public void AddJamesWebbClientServicesCorrectlyRegistersServicesTest()
    {
        const string expected = "test-api-key";

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(
                initialData: new Dictionary<string, string?>()
                {
                    [$"{JamesWebbApiSettings.SectionName}:Key"] = expected
                })
            .Build();

        services.AddJamesWebbClientServices(configuration);

        var provider = services.BuildServiceProvider();

        var options =
            provider.GetRequiredService<IOptions<JamesWebbApiSettings>>();
        Assert.NotNull(options);

        var actual = options.Value.Key;
        Assert.Equal(expected, actual);

        Assert.NotNull(provider.GetRequiredService<IJamesWebbClient>());
    }

    [Fact(Skip = "Integration test.")]

    public async void AddJamesWebbClientServicesCorrectlyResolvesClientTest()
    {
        var expected = Environment.GetEnvironmentVariable(
            $"{JamesWebbApiSettings.SectionName}__Key");
        Assert.True(expected is { Length: > 0 });

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        services.AddJamesWebbClientServices(configuration);

        var provider = services.BuildServiceProvider();

        var options =
            provider.GetRequiredService<IOptions<JamesWebbApiSettings>>();
        Assert.NotNull(options);

        var actual = options.Value.Key;
        Assert.Equal(expected, actual);

        var client = provider.GetRequiredService<IJamesWebbClient>();
        Assert.NotNull(client);

        // Let's query as many observations as we can for 10 seconds.
        // After ten seconds, we'll cancel the request and assert that
        // the request was canceled.

        // Tally the total number for reference.
        var runningTotal = 0;
        await Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            using var cancellationTokenSource =
                new CancellationTokenSource(TimeSpan.FromSeconds(1));

            CancellationToken cancellationToken = cancellationTokenSource.Token;

            await foreach (var (program, observation) in
                client.GetAllByProgramAsAsyncEnumerable(200, cancellationToken))
            {
                _output.WriteLine(
                    $"[Program.Id = {program.Program}] {observation}");

                ++ runningTotal;
            }
        });

        Assert.True(runningTotal is > 0);

        _output.WriteLine($"Retrieved a total of {runningTotal} observations.");
    }

    [Fact(Skip = "Integration test.")]

    public async void AddJamesWebbClientServicesReturnsFunctioningClient()
    {
        var expected = Environment.GetEnvironmentVariable(
            $"{JamesWebbApiSettings.SectionName}__Key");
        Assert.True(expected is { Length: > 0 });

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        services.AddJamesWebbClientServices(configuration);

        var provider = services.BuildServiceProvider();

        var options =
            provider.GetRequiredService<IOptions<JamesWebbApiSettings>>();
        Assert.NotNull(options);

        var actual = options.Value.Key;
        Assert.Equal(expected, actual);

        var client = provider.GetRequiredService<IJamesWebbClient>();
        Assert.NotNull(client);

        // Let's query as many observations as we can for 10 seconds.
        // After ten seconds, we'll cancel the request and assert that
        // the request was canceled.

        // Tally the total number for reference.
        var runningTotal = 0;
        using var cancellationTokenSource =
            new CancellationTokenSource(TimeSpan.FromSeconds(30));

        CancellationToken cancellationToken = cancellationTokenSource.Token;

        await foreach (var (suffix, observation) in
            client.GetAllBySuffixAsAsyncEnumerable(200, cancellationToken))
        {
            _output.WriteLine(
                $"[Suffix = {suffix.Suffix}] {observation}");

            ++ runningTotal;
        }

        Assert.True(runningTotal is > 0);

        _output.WriteLine($"Retrieved a total of {runningTotal} observations.");
    }
}
