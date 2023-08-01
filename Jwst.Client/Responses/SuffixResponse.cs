// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record class SuffixResponse(
    string Mission,
    InstrumentResponse[] Instruments,
    string Suffix,
    string Description);
