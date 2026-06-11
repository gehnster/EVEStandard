# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

EVEStandard is a C# client library for the EVE Online ESI API, published to NuGet as `PointyHatGames.EVEStandard`. The library project (`EVEStandard/`) targets `netstandard2.1` and `netstandard2.0`; the test project (`EVEStandard.Tests/`) targets `net10.0`.

## Commands

```powershell
dotnet restore
dotnet build --configuration Release          # GeneratePackageOnBuild=true, so a .nupkg is produced
dotnet test                                   # run all xUnit tests
dotnet test --filter "FullyQualifiedName~APIBaseTests"   # run one class
dotnet test --filter "FullyQualifiedName~EnumToStringConversionTests.SomeMethod"  # run one test
```

CI (`.github/workflows/dotnet-core.yml`) runs restore → build (Release) → test on push/PR to `master`. `publish.yml` pushes the NuGet package on master.

## Architecture

Two entry-point classes that users construct directly:

- **`EVEStandardAPI`** — the ESI data client. Its constructor builds a single shared `HttpClient` and instantiates every endpoint group (e.g. `Alliance`, `Character`, `Corporation`) as a public property, injecting the shared `HttpClient` into each. Access endpoints via `eve.Alliance.GetAllianceInfoAsync(...)`, etc.
- **`SSOv2`** — OAuth2 / SSO. Supports both Basic Auth (requires client secret) and PKCE (no secret) flows, plus token refresh, revocation, and JWT validation (`GetCharacterDetailsAsync` validates the access token against EVE's JWKS).

### Endpoint groups (`EVEStandard/API/`)

Each ESI category is one class deriving from **`APIBase`** (one file per group: `Alliance.cs`, `Character.cs`, ...). `APIBase` is the heart of the HTTP layer and centralizes everything an endpoint method needs:

- `GetAsync` / `PostAsync` / `PutAsync` / `DeleteAsync` → `RequestAsync`, which builds the URI from `ESI_BASE`, attaches the `X-Tenant` (datasource) and `X-Compatibility-Date` headers, sets the Bearer token, and handles `If-None-Match`.
- `CheckAuth(auth, scope)` — validates the `AuthDTO` and that the required scope is present before a call. Throws `EVEStandardScopeNotAcquired` if missing.
- `ProcessResponse` — maps HTTP status codes to behavior: success codes populate the model; 401→`EVEStandardUnauthorizedException`, 403→`EVEStandardScopeNotAcquired`, 304→`NotModified`, 429/520/422/5xx→error message on the model. Also handles manual gzip decompression and `Retry-After`.
- `PopulateRateLimitHeaders` — reads the `X-Ratelimit-*` headers into the response.
- `ParseCursorInfo` — extracts the `cursor` object (before/after tokens) for cursor-based pagination.
- `ReturnModelDTO<T>` — deserializes JSON into `ESIModelDTO<T>` and copies over metadata (ETag, Expires, MaxPages, rate-limit info, cursor).

### Request/response DTOs (`EVEStandard/Models/API/`)

- **`AuthDTO`** — passed to authenticated endpoint methods; carries the access token, character id, and granted scopes.
- **`ESIModelDTO<T>`** — the public return type of nearly every endpoint method. Wraps `Model` (the deserialized payload) plus metadata: `ETag`, `Expires`, `LastModified`, `MaxPages` (page-based pagination), `Cursor` (cursor-based pagination), and rate-limit fields (`RateLimitGroup`, `RateLimitRemaining`, `RetryAfter`, etc.).
- **`APIResponse`** — internal raw response used between `APIBase` and `ReturnModelDTO`.

### Other directories

- `Models/` — POJO-style payload models, deserialized with `System.Text.Json`.
- `Models/SSO/` — token and character-detail models for `SSOv2`.
- `Enumerations/` — includes `Scopes` (ESI OAuth scope string constants), `DataSource` (Tranquility/Serenity), `CompatibilityDate`, and `Language`.
- `Utilities/` — `ImageServer` (character/corp/type image URL helpers) and `Formulas`.

### Datasource and compatibility date

ESI is selected by `DataSource` (Tranquility → `esi.evetech.net`, Serenity → `esi.evepc.163.com`). `CompatibilityDate` is an enum whose name is converted to the `X-Compatibility-Date` header value by stripping a leading `v` and replacing `_` with `-` (e.g. `v2018_07_18` → `2018-07-18`).

## Adding a new endpoint

See `AddingNewAPI.md`. A method on an `APIBase`-derived class typically: calls `CheckAuth` when a scope is required, builds a `queryParameters` dictionary, uses string interpolation for the path with explicit version (e.g. `$"/v3/characters/{auth.CharacterId}/assets/"`), calls the appropriate `*Async` helper, then calls `CheckResponse(nameof(Method), ...)` and returns `ReturnModelDTO<T>(responseModel)`. New error codes go in `APIBase.cs`. Pull XML-doc descriptions from the ESI Swagger page.

## Conventions

- API ids and model integer fields are `long` (a deliberate migration — do not reintroduce `int` for these).
- Endpoint method names embed the ESI version (`...V3Async`) and must match the version in both the path and `CheckResponse`.
- Logging goes through `LibraryLogging.CreateLogger<T>()`; a consumer wires it up via `EVEStandardAPI.AddLogging(loggerFactory)`.
