// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

/// <summary>
/// A generic response object for the JWST API.
/// </summary>
/// <typeparam name="T">The type of response's <paramref name="Body"/> value.</typeparam>
/// <param name="StatusCode">The response's HTTP status code.</param>
/// <param name="Body">The value of the response's body as <typeparamref name="T"/>.</param>
/// <param name="Error">The response's error. Empty when successful.</param>
public record ResponseOf<T>(
    int StatusCode,
    T Body,
    string? Error);
