// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record ObservationDetails(
    string Id,
    string ObservationId,
    int Program,
    SuffixDetails Details,
    string FileType,
    string Thumbnail,
    string Location);
