// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record ObservationResponse(
    int StatusCode,
    ObservationDetails[] Body,
    string? Error) :
    ResponseOf<ObservationDetails[]>(
        StatusCode,
        Body,
        Error);
