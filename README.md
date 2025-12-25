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

## Donate
Feel like donating to show appreciation for the time and effort I've put into creating and maintaining this library? Consider either becoming a GitHub Sponsor or donating ISK to ```Gehnster```
