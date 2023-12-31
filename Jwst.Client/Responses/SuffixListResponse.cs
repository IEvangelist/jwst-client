﻿// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record SuffixListResponse(
    int StatusCode,
    SuffixDetails[] Body,
    string? Error) :
    ResponseOf<SuffixDetails[]>(
        StatusCode,
        Body,
        Error);
