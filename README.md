# The "James Webb Space Telescope API" .NET Client Library

[![.NET](https://github.com/IEvangelist/jwst-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/IEvangelist/jwst-client/actions/workflows/dotnet.yml)

This is a .NET source-generated client library for the [James Webb Space Telescope API](https://api.jwstapi.com)

## Get started

Sign up for a free API key with an email address here https://jwstapi.com.

## Configure the API key

If you're using an _appsettings.json:_

```json
{
    "JamesWebbApi": {
        "Key": "<Your API Key>"
    }
}
```

Or perhaps an environment variable:

```
setx JamesWebbApi__Key "<Your API Key>"
```

## Consumption

```csharp
var builder = Host.CreateApplicationBuilder(args);

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