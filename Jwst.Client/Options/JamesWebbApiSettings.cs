﻿// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Options;

[OptionsValidator]
public sealed partial class JamesWebbApiSettings : IValidateOptions<JamesWebbApiSettings>
{
    public const string SectionName = "JamesWebbApi";

    /// <summary>
    /// The James Webb Client API Key, corresponds to the <c>X-API-KEY</c> HTTP Header.
    /// Generate a free API key here, https://jwstapi.com.
    /// </summary>
    [Required]
    public required string Key { get; init; }
}
