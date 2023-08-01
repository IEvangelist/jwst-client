// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client;

/// <summary>
/// https://api.jwstapi.com
/// </summary>
[
    AutoClient(nameof(IJamesWebbClient)),
    StaticHeader("User-Agent", "dotnet-jwst-client")
]
public interface IJamesWebbClient
{
    [Get("/")]
    public Task<VersionResponse> GetVersionAsync(
        CancellationToken cancellationToken = default);

    [Get("/program/list")]
    public Task<ProgramListResponse> GetProgramListAsync(
        CancellationToken cancellationToken = default);

    [Get("/suffix/list")]
    public Task<SuffixListResponse> GetSuffixListAsync(
        CancellationToken cancellationToken = default);

    [Get("/observation/{observationId}")]
    public Task<VersionResponse> GetByObservationIdAsync(
        string observationId,
        [Query] int page = 1,
        [Query] int perPage = 10,
        CancellationToken cancellationToken = default);
}   
