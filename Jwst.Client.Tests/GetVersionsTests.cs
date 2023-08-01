// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Tests;

public class GetVersionsTests
{
    private readonly ITestOutputHelper _output;

    public GetVersionsTests(ITestOutputHelper output) => _output = output;

    [Fact]
    public async Task GetVersionReturnsSuccessfullyTest()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new("https://api.jwstapi.com")
        };

        var options = new AutoClientOptions
        {
            JsonSerializerOptions = new(JsonSerializerDefaults.Web)
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
            }
        };

        var client = new JamesWebbClient(httpClient, options);

        var version = await client.GetVersionAsync(CancellationToken.None);

        _output.WriteLine("Version: {0}", version);

        Assert.NotNull(version);
        Assert.True(version.IsSuccessful, $"StatusCode: {version.StatusCode}");
        Assert.Empty(version.Error ?? string.Empty);
        Assert.NotNull(version.Version);
    }

    [Fact]
    public async Task GetVersionRespectsCancellationsTest()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new("https://api.jwstapi.com")
        };

        var options = new AutoClientOptions
        {
            JsonSerializerOptions = new(JsonSerializerDefaults.Web)
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
            }
        };

        var client = new JamesWebbClient(httpClient, options);

        // Create a cancellation token, that is already canceled
        var cancellationToken = new CancellationToken(true);

        await Assert.ThrowsAsync<TaskCanceledException>(
            testCode: async () => await client.GetVersionAsync(cancellationToken));
    }
}