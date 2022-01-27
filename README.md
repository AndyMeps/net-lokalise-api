# Lokalise.Api

> **Note:** This NuGet package is not maintained by Lokalise. This is a personal project and is in no-way affiliated or sponsored by Lokalise.

## Installation

> `Install-Package Lokalise.Api`

## Basic Usage

To start making API requests, instantiate a new `LokaliseClient` object:

```csharp
using Lokalise.Api;

var client = new LokaliseClient("{LOKALISE_API_KEY}");
```

If you have an `HttpClient` instance in particular you want to use, it can be passed in as a second parameter. Otherwise `LokaliseClient` will spin one up to use per instance.

### Collections

Sections of the API are split in to collections, these can be accessed by using the collection name on the client:

```csharp
client.Files
client.Keys
client.Projects
// etc
```

Endpoints on the API should match the naming convention used on the Lokalise API documentation.

### API Options
Almost all API endpoints that support additional options can be provided by specifying a configuration object, unspecified options are not sent to the API, so Lokalise defaults will still apply.

```csharp
var files = client.Files.ListAsync("{PROJECT_ID}", cfg => {
  cfg.FilterFilename = "%LANG_ISO%.json";
});
```

### Branches

Branch names can usually be provided either by setting a configuration option on each method call, or by providing it in the `projectId:branchName` format supported by lokalise.

If a branch name is provided in the `projectId`, the configuration value will be ignored.

```csharp
var files = client.Files.ListAsync("{PROJECT_ID}", cfg => {
  cfg.Branch = "my-branch"; // To set branch name
});
```

OR

```csharp
var files = client.Files.ListAsync("{PROJECT_ID}:my-branch");
```

## Lokalise API Documentation

[Lokalise API Documentation](https://app.lokalise.com/api2docs/curl/)
