// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Json;

internal sealed class SnakeOrCamelCaseNamingPolicy : JsonNamingPolicy
{
    private static readonly DefaultObjectPoolProvider s_objectPoolProvider = new();
    private static readonly ObjectPool<StringBuilder> s_stringBuilderPool =
        s_objectPoolProvider.CreateStringBuilderPool();

    internal static SnakeOrCamelCaseNamingPolicy Instance { get; } = new();

    public override string ConvertName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var isSnakeCase = name.Contains('_');
        var isCamelCase = char.IsLower(name[0]);

        return (isSnakeCase, isCamelCase) switch
        {
            (true, _) => FromSnakeCaseToHungarianCase(name),
            (_, true) => FromCamelCaseToHungarianCase(name),

            _ => name
        };
    }

    private static string FromSnakeCaseToHungarianCase(ReadOnlySpan<char> name)
    {
        StringBuilder builder = s_stringBuilderPool.Get();
        try
        {
            var toUpper = false;
            for (var index = 0; index < name.Length; ++ index)
            {
                if (index is 0)
                {
                    builder.Append(char.ToUpper(name[index]));
                    continue;
                }

                var @char = name[index];
                if (@char is '_')
                {
                    toUpper = true;
                }
                else
                {
                    if (toUpper)
                    {
                        builder.Append(char.ToUpper(@char));
                        toUpper = false;
                    }
                    else
                    {
                        builder.Append(@char);
                    }
                }
            }

            return builder.ToString();
        }
        finally
        {
            builder.Clear();
            s_stringBuilderPool.Return(builder);
        }
    }

    private static string FromCamelCaseToHungarianCase(ReadOnlySpan<char> name)
    {
        StringBuilder builder = s_stringBuilderPool.Get();
        try
        {
            for (var index = 0; index < name.Length; ++index)
            {
                if (index is 0)
                {
                    builder.Append(char.ToUpper(name[index]));
                    continue;
                }

                var @char = name[index];
                builder.Append(@char);
            }

            return builder.ToString();
        }
        finally
        {
            builder.Clear();
            s_stringBuilderPool.Return(builder);
        }
    }
}
