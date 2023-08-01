// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record class SuffixListResponse(
    [property: JsonPropertyName("body")]
    SuffixResponse[] Suffixes,
    int StatusCode,
    string? Error
    ) : Response(StatusCode, Error);
