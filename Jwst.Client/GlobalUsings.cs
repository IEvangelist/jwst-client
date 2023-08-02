// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

global using System.ComponentModel.DataAnnotations;
global using System.Runtime.CompilerServices;
global using System.Text;
global using System.Text.Json;

global using Jwst.Client.Json;
global using Jwst.Client.Options;
global using Jwst.Client.Responses;

global using Microsoft.Extensions.Compliance.Redaction;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Http.AutoClient;
global using Microsoft.Extensions.Http.Resilience;
global using Microsoft.Extensions.Http.Telemetry.Latency;
global using Microsoft.Extensions.Http.Telemetry.Logging;
global using Microsoft.Extensions.Http.Telemetry.Metering;
global using Microsoft.Extensions.ObjectPool;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.Telemetry.Latency;

// For testing purposes only
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo(
    assemblyName: "Jwst.Client.Tests")]