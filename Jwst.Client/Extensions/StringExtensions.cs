// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Extensions;

internal static class StringExtensions
{
    /// <summary>
    /// Converts a given <paramref name="str"/> to <c>snake_case</c>.
    /// </summary>
    /// <param name="str">The <see cref="string"/> value to convert to <c>snake_case</c>.</param>
    /// <returns>The given <paramref name="str"/> to convert to <c>snake_case</c>.</returns>
    internal static string ToSnakeCase(this string str) =>
        string.Concat(
            values: str.Select(
                selector: static (x, i) => i > 0
                && char.IsUpper(x)
                    ? $"_{x}"
                    : x.ToString()))
            .ToLower();
}
