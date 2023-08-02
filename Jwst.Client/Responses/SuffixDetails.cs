// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Responses;

public record SuffixDetails(string Mission, string Suffix, string Description)
{
    public Tool[] Instruments { get; set; } = Array.Empty<Tool>();
}
