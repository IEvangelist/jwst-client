# The "James Webb Space Telescope API" .NET Client Library

[![.NET](https://github.com/IEvangelist/jwst-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/IEvangelist/jwst-client/actions/workflows/dotnet.yml)

This is a .NET source-generated client library for the [James Webb Space Telescope API](https://api.jwstapi.com)

## Get started

```csharp
var builder = Host.CreateApplicationBuilder(args);

// Assumes you've configured the: "JamesWebbApi__Key"
builder.Services.AddJameWebbClientServices(builder.Configuration);

using var host = builder.Build();

var client = host.Services.GetRequiredService<IJamesWebbClient>();

// TODO: Use the client
```

## Notes

This library relies on the following NuGet packages:

- 📦 [`Microsoft.Extensions.Compliance.Redaction`](https://nuget.org/packages/Microsoft.Extensions.Compliance.Redaction)
- 📦 [`Microsoft.Extensions.Http.AutoClient`](https://nuget.org/packages/Microsoft.Extensions.Http.AutoClient)
- 📦 [`Microsoft.Extensions.Http.Resilience`](https://nuget.org/packages/Microsoft.Extensions.Http.Resilience)
- 📦 [`Microsoft.Extensions.Http.Telemetry`](https://nuget.org/packages/Microsoft.Extensions.Http.Telemetry)
- 📦 [`Microsoft.Extensions.Options.ConfigurationExtension`](https://nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtension)