# EVE Standard - A C# Library to access the EVE Online ESI API
[![Master Branch](https://github.com/gehnster/EVEStandard/actions/workflows/publish.yml/badge.svg)](https://github.com/gehnster/EVEStandard/actions/workflows/publish.yml)

This library is meant to access the EVE Online ESI API through a C# library. This library was built using .NET Standard so as to be compatible with as many recent .NET frameworks as possible.

## [Discord Server](https://discord.gg/SVyVze5)

## Example of how the library works
You can find examples of how to use the library [here](https://github.com/gehnster/EVEStandard-Examples)

## NuGet
The package is now on NuGet! You can find it here: [EVEStandard NuGet Page](https://www.nuget.org/packages/PointyHatGames.EVEStandard)

## ESI Rate Limiting

EVEStandard fully supports ESI's rate limiting model using a floating window token bucket system.

### Rate Limit Groups

ESI organizes endpoints into rate limit groups, where related routes share the same rate limit bucket. Each group tracks token consumption independently, allowing you to make requests to different groups without affecting each other's limits.

**Token Costs:**
- 2XX responses: 2 tokens (successful)
- 3XX responses: 1 token (redirection/not modified)
- 4XX responses: 5 tokens (client error)
- 5XX responses: 0 tokens (server error - not penalized)

**Response Headers:**
- `X-Ratelimit-Group`: Identifies which rate limit group the endpoint belongs to (e.g., "char-location", "universe-types")
- `X-Ratelimit-Limit`: Rate limit configuration (e.g., "150/15m" = 150 tokens per 15 minutes)
- `X-Ratelimit-Remaining`: Number of request tokens remaining in this group's bucket
- `X-Ratelimit-Used`: Number of tokens consumed by the current request

When you exceed a group's rate limit, you will receive HTTP 429 responses with a `Retry-After` header indicating how many seconds to wait before retrying.

### Accessing Rate Limit Information

All rate limiting information is automatically captured and made available through the `ESIModelDTO<T>` object returned by API calls:

```csharp
var result = await eveClient.Universe.GetUniverseTypes();

// Rate limiting information
string rateLimitGroup = result.RateLimitGroup;      // e.g., "universe-types"
string rateLimitConfig = result.RateLimitLimit;     // e.g., "150/15m"
int requestsRemaining = result.RateLimitRemaining;  // tokens left in bucket
int tokensUsed = result.RateLimitUsed;              // tokens consumed by this request
int retryAfter = result.RetryAfter;                 // seconds to wait (only set in 429 responses)
```

### Best Practices

1. **Monitor rate limits by group**: Track the `RateLimitGroup` to understand which endpoint groups you're using heavily
2. **Check remaining tokens**: Monitor `RateLimitRemaining` to avoid hitting limits
3. **Handle 429 errors**: If you receive a 429 error, respect the `Retry-After` header before retrying
4. **Implement exponential backoff**: When retrying failed requests, use exponential backoff to avoid making the situation worse
5. **Cache responses**: Use ETags and the `If-None-Match` header to minimize token consumption (304 responses only cost 1 token)
6. **Be aware of error costs**: 4XX errors cost 5 tokens, so validate inputs before making requests

For more information about ESI rate limiting, see the [ESI documentation](https://developers.eveonline.com/docs/services/esi/rate-limiting/).

## Caching

ESI is moving from time-based cache expiration to event-driven cache invalidation: responses are refreshed when Tranquility reports that the underlying data has actually changed, rather than after a fixed duration. As a result the `Expires` header is no longer meaningful and the `Cache-Control` header is now the source of truth for how long a response may be considered fresh.

EVEStandard reflects this on the `ESIModelDTO<T>` returned by every call:

```csharp
var result = await eveClient.Skills.GetCharacterSkillsAsync(auth, ifNoneMatch: cachedETag);

TimeSpan? freshFor = result.CacheControlMaxAge; // Cache-Control max-age, e.g. 00:02:00
string etag = result.ETag;                      // store this and pass it back as ifNoneMatch
bool unchanged = result.NotModified;            // true on a 304 (only costs 1 rate-limit token)
```

### Best Practices

1. **Revalidate with ETags**: store the `ETag` from a response and pass it as the `ifNoneMatch` argument on the next request. A `304 Not Modified` (`NotModified == true`) costs only 1 rate-limit token and tells you your cached copy is still current.
2. **Use `CacheControlMaxAge`, not `Expires`**: decide when to revalidate based on `CacheControlMaxAge`. The `Expires` property is deprecated (and marked `[Obsolete]`) because event-driven invalidation makes it unreliable.
3. **Don't poll faster than the data changes**: with event-driven invalidation, revalidating with an ETag after `CacheControlMaxAge` elapses is enough — tighter polling just consumes rate-limit tokens for `304`s.

For more information, see [Smarter Caching: When Events Drive Invalidation](https://developers.eveonline.com/blog/smarter-caching-when-events-drive-invalidation).

## Pagination

EVEStandard supports both traditional page-based pagination and the newer cursor-based pagination.

### Page-Based Pagination

Traditional ESI endpoints use page-based pagination with a `page` parameter. The total number of pages is available in the `MaxPages` property:

```csharp
var result = await eveClient.Corporation.GetCorporationShareholdersAsync(auth, corporationId, page: 1);

int totalPages = result.MaxPages;
var shareholders = result.Model;
```

### Cursor-Based Pagination

Some newer ESI endpoints (such as corporation projects) use cursor-based pagination. Instead of page numbers, these endpoints use opaque tokens to navigate through results:

```csharp
// First request - no cursor parameters
var result = await eveClient.Corporation.GetCorporationProjectsAsync(auth, corporationId);

var projects = result.Model;
var cursor = result.Cursor;

// Next page - use the "after" token
if (cursor?.After != null)
{
    var nextPage = await eveClient.Corporation.GetCorporationProjectsAsync(
        auth, corporationId, after: cursor.After);
}

// Previous page - use the "before" token
if (cursor?.Before != null)
{
    var prevPage = await eveClient.Corporation.GetCorporationProjectsAsync(
        auth, corporationId, before: cursor.Before);
}
```

**Important notes about cursor-based pagination:**
- Cursor tokens are opaque strings - do not parse or modify them
- Use the `after` token to get newer/next results
- Use the `before` token to get older/previous results
- Tokens are returned in the `Cursor` property of the `ESIModelDTO<T>` result
- Results are ordered by modification date, with most recently modified items last

For more information about cursor-based pagination, see the [ESI Cursor-Based Pagination documentation](https://developers.eveonline.com/docs/services/esi/pagination/cursor-based/).

## Equinox: Sovereignty, Structures & Access Lists

The Equinox additions to ESI are available starting at compatibility date **2026-05-19**. Construct `EVEStandardAPI` with `CompatibilityDate.v2026_05_19` (or later) to reach these routes:

```csharp
var eve = new EVEStandardAPI("MyApp/1.0 (contact@example.com)", DataSource.Tranquility, CompatibilityDate.v2026_05_19, TimeSpan.FromSeconds(30));
```

New endpoints:

| Accessor | Endpoint | Scope |
|---|---|---|
| `eve.Sovereignty.GetSovereigntySystemsAsync()` | `/sovereignty/systems` | public |
| `eve.Activities.ListRaidableSkyhooksAsync()` | `/skyhooks/raidable` | public |
| `eve.Activities.ListMercenaryTacticalOperationsAsync(auth)` / `GetMercenaryTacticalOperationAsync(auth, operationId)` | `/characters/{id}/mercenary-tactical-operations` | `esi-activities.read_character.v1` |
| `eve.AccessList.ListAccessListsAsync(auth)` / `GetAccessListAsync(auth, accessListId)` | `/characters/{id}/access-lists` | `esi-access.read_lists.v1` |
| `eve.Structures.ListCharacterMercenaryDensAsync(auth)` / `GetCharacterMercenaryDenAsync(auth, denId)` | `/characters/{id}/structures/mercenary-dens` | `esi-structures.read_character.v1` |
| `eve.Structures.ListCorporationSkyhooksAsync(auth, corporationId)` / `GetCorporationSkyhookAsync(...)` | `/corporations/{id}/structures/skyhooks` | `esi-structures.read_corporation.v1` |
| `eve.Structures.ListCorporationSovereigntyHubsAsync(auth, corporationId)` / `GetCorporationSovereigntyHubAsync(...)` | `/corporations/{id}/structures/sovereignty-hubs` | `esi-structures.read_corporation.v1` |

`GetSovereigntySystemsAsync` combines occupancy and structure information in a single response, including the Activity Defense Multiplier and the military, industry and strategic development indexes (`SovereigntyDevelopment`).

### Removed at compatibility date 2026-05-19

`/sovereignty/map` and `/sovereignty/structures` were removed and replaced by `/sovereignty/systems`. The corresponding methods `Sovereignty.ListSovereigntyOfSystemsAsync` and `Sovereignty.ListSovereigntyStructuresAsync` are marked `[Obsolete]`; they still function at older compatibility dates but will return errors at 2026-05-19 and later. Migrate to `GetSovereigntySystemsAsync`.

For details, see [Equinox on ESI: Structures, Sovereignty and Access Lists](https://developers.eveonline.com/blog/equinox-on-esi-structures-sovereignty-and-access-lists).

## Cradle of War: Character Titles & Achievements

At compatibility date **2026-06-09**, `GET /characters/{character_id}` (`Character.GetCharacterInfoAsync`) changed:

- `title` was renamed to `corporation_title` → use `CharacterInfo.CorporationTitle` (the old `CharacterInfo.Title` is marked `[Obsolete]` and only populated at earlier compatibility dates).
- New `CharacterInfo.CharacterTitleId` (the UUID of the title the character currently displays).
- New `CharacterInfo.AchievementScore` (the character's total achievement score).

Only the fields applicable to your chosen compatibility date are populated; the others stay null. For details, see [Cradle of War on ESI: Character Titles and Achievements](https://developers.eveonline.com/blog/cradle-of-war-on-esi-character-titles-and-achievements).

## Donate
Feel like donating to show appreciation for the time and effort I've put into creating and maintaining this library? Consider either becoming a GitHub Sponsor or donating ISK to ```Gehnster```
