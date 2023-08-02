// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record ProgramListResponse(
    int StatusCode,
    ListedProgram[] Body,
    string? Error) :
    ResponseOf<ListedProgram[]>(
        StatusCode,
        Body,
        Error);
