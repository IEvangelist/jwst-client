// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record VersionResponse(
    int StatusCode,
    string Body,
    string? Error) :
    ResponseOf<string>(
        StatusCode,
        Body,
        Error);
