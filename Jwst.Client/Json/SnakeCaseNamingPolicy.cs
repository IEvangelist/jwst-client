// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Json;

internal sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public static SnakeCaseNamingPolicy Instance { get; } = new();

    public override string ConvertName(string name) => name.ToSnakeCase();
}
