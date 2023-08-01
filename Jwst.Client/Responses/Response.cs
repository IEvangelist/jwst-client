// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

/// <summary>
/// A representation of a shared response that all
/// <see cref="IJamesWebbClient"/> APIs will return.
/// </summary>
/// <param name="StatusCode">The HTTP status code of the response.</param>
/// <param name="Error">The error message of the response.</param>
public record class Response(
    int StatusCode,
    string? Error)
{
    private int? _statusCode;

    public bool IsSuccessful
    {
        get => (_statusCode ?? (int)(_statusCode = 200)) is 200;
        init => _statusCode = StatusCode is <= 0 ? 200 : StatusCode;
    }
}
