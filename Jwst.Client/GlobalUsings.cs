// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

global using System.Text.Json;
global using System.Text.Json.Serialization;

global using Jwst.Client.Extensions;
global using Jwst.Client.Options;
global using Jwst.Client.Responses;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Http.AutoClient;
global using Microsoft.Extensions.Options;

// For testing purposes only
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo(
    assemblyName: "Jwst.Client.Tests")]