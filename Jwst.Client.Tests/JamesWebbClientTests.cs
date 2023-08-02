// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Tests;

public class JamesWebbClientTests
{
    private readonly ITestOutputHelper _output;

    public JamesWebbClientTests(ITestOutputHelper output) => _output = output;

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
                PropertyNamingPolicy = SnakeOrCamelCaseNamingPolicy.Instance
            }
        };

        var client = new JamesWebbClient(httpClient, options);

        var version = await client.GetVersionAsync(CancellationToken.None);

        _output.WriteLine("Version: {0}", version);

        Assert.NotNull(version);
        Assert.Equal(200, version.StatusCode);
        Assert.Empty(version.Error ?? string.Empty);
        Assert.NotNull(version.Body);
    }

    [Fact]
    public async Task RoutesRequiringAuthHeadersFailWithoutHeaderTest()
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
                PropertyNamingPolicy = SnakeOrCamelCaseNamingPolicy.Instance
            }
        };

        var client = new JamesWebbClient(httpClient, options);

        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetAllByFileTypeAsync("", 1, 10, CancellationToken.None));
        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetAllBySuffixAsync("", 1, 10, CancellationToken.None));
        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetByObservationIdAsync("", 1, 10, CancellationToken.None));
        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetByProgramIdAsync(2731, 1, 10, CancellationToken.None));
        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetProgramListAsync(CancellationToken.None));
        await Assert.ThrowsAsync<AutoClientException>(
            () => client.GetSuffixListAsync(CancellationToken.None));
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
                PropertyNamingPolicy = SnakeOrCamelCaseNamingPolicy.Instance
            }
        };

        var client = new JamesWebbClient(httpClient, options);

        // Create a cancellation token, that is already canceled
        var cancellationToken = new CancellationToken(true);

        await Assert.ThrowsAsync<TaskCanceledException>(
            testCode: async () => await client.GetVersionAsync(cancellationToken));
    }
}