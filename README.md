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

## Donate
Feel like donating to show appreciation for the time and effort I've put into creating and maintaining this library? Consider either becoming a GitHub Sponsor or donating ISK to ```Gehnster```
