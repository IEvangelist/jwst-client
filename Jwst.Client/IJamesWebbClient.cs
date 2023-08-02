// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client;

/// <summary>
/// The James Webb API client that exposes the
/// functionality from the https://api.jwstapi.com.
/// </summary>
[
    AutoClient(nameof(IJamesWebbClient)),
    StaticHeader("User-Agent", "dotnet-jwst-client")
]
public interface IJamesWebbClient
{
    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com, which
    /// returns a <see cref="VersionResponse"/> with version details.
    /// </summary>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="VersionResponse"/> with version details.
    /// </returns>
    /// <remarks>
    /// This is the only route that is unauthenticated.
    /// </remarks>
    [Get("/")]
    public Task<VersionResponse> GetVersionAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/program/list, which
    /// returns a <see cref="ProgramListResponse"/> with program details.
    /// </summary>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="ProgramListResponse"/> with program details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/program/list")]
    public Task<ProgramListResponse> GetProgramListAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/suffix/list, which
    /// returns a <see cref="SuffixListResponse"/> with suffix details.
    /// </summary>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="SuffixListResponse"/> with suffix details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/suffix/list")]
    public Task<SuffixListResponse> GetSuffixListAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/observation/{observationId}, which
    /// returns a <see cref="ObservationResponse"/> with observation details.
    /// </summary>
    /// <param name="observationId">The observation identifier used as part of the API route.</param>
    /// <param name="page">An optional page number, used as a query string parameter.</param>
    /// <param name="perPage">An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="ObservationResponse"/> with observation details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/observation/{observationId}")]
    public Task<ObservationResponse> GetByObservationIdAsync(
        string observationId,
        [Query] int page = 1,
        [Query] int perPage = 10,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/all/suffix/{suffixId}, which
    /// returns a <see cref="ObservationResponse"/> with observation details.
    /// </summary>
    /// <param name="suffixId">The suffix identifier used as part of the API route.</param>
    /// <param name="page">An optional page number, used as a query string parameter.</param>
    /// <param name="perPage">An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="ObservationResponse"/> with observation details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/all/suffix/{suffixId}")]
    public Task<ObservationResponse> GetAllBySuffixAsync(
        string suffixId,
        [Query] int page = 1,
        [Query] int perPage = 10,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/all/type/{fileType}, which
    /// returns a <see cref="ObservationResponse"/> with observation details.
    /// </summary>
    /// <param name="fileType">The file type used as part of the API route: <c>jpg, ecsv, fits, or json</c></param>
    /// <param name="page">An optional page number, used as a query string parameter.</param>
    /// <param name="perPage">An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="ObservationResponse"/> with observation details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/all/type/{fileType}")]
    public Task<ObservationResponse> GetAllByFileTypeAsync(
        string fileType,
        [Query] int page = 1,
        [Query] int perPage = 10,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP GET request to https://api.jwstapi.com/program/id/{programId}, which
    /// returns a <see cref="ObservationResponse"/> with observation details.
    /// </summary>
    /// <param name="programId">The program identifier used as part of the API route.</param>
    /// <param name="page">An optional page number, used as a query string parameter.</param>
    /// <param name="perPage">An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A <see cref="ObservationResponse"/> with observation details.
    /// </returns>
    /// <remarks>
    /// Requires a valid <see cref="JamesWebbApiSettings.Key"/> to be set. If you need an API key,
    /// signup for free with a valid email address here: https://jwstapi.com. The appropriate
    /// <c>X-API-KEY</c> HTTP Header will be used automatically as part of the request.
    /// </remarks>
    [Get("/program/id/{programId}")]
    public Task<ObservationResponse> GetByProgramIdAsync(
        int programId,
        [Query] int page = 1,
        [Query] int perPage = 10,
        CancellationToken cancellationToken = default);
}
