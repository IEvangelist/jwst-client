// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record class ProgramListResponse(
    [property: JsonPropertyName("body")] ProgramResponse[] Programs,
    int StatusCode,
    string? Error)
    : Response(StatusCode, Error);
