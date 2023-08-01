// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

/// <summary>
/// 
/// </summary>
/// <param name="Version"></param>
/// <param name="StatusCode"></param>
/// <param name="Error"></param>
public record class VersionResponse(
    [property: JsonPropertyName("body")] string Version,
    int StatusCode,
    string? Error)
    : Response(StatusCode, Error);
