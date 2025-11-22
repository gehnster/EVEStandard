# EVE Standard - A C# Library to access the EVE Online ESI API
[![Master Branch](https://github.com/gehnster/EVEStandard/actions/workflows/publish.yml/badge.svg)](https://github.com/gehnster/EVEStandard/actions/workflows/publish.yml)

This library is meant to access the EVE Online ESI API through a C# library. This library was built using .NET Standard so as to be compatible with as many recent .NET frameworks as possible.

## [Discord Server](https://discord.gg/SVyVze5)

## Example of how the library works
You can find examples of how to use the library [here](https://github.com/gehnster/EVEStandard-Examples)

## NuGet
The package is now on NuGet! You can find it here: [EVEStandard NuGet Page](https://www.nuget.org/packages/PointyHatGames.EVEStandard)

## ESI Rate Limiting

EVEStandard fully supports ESI's rate limiting model, which includes two types of limits:

### Error Rate Limiting
ESI tracks the number of failed requests (4xx/5xx errors) you make within a time window. If you exceed this limit, you will receive HTTP 420 responses until the error window resets.

**Response Headers:**
- `X-ESI-Error-Limit-Remain`: Number of errors remaining before being blocked
- `X-ESI-Error-Limit-Reset`: Seconds until the error counter resets

### Request Rate Limiting  
ESI limits the overall number of requests you can make within a time window using a token bucket algorithm. If you exceed this limit, you will receive HTTP 429 responses.

**Response Headers:**
- `X-Ratelimit-Limit`: Rate limit configuration (e.g., "150/15m")
- `X-Ratelimit-Remaining`: Number of request tokens remaining
- `X-Ratelimit-Reset`: Seconds until the rate limit window resets

### Accessing Rate Limit Information

All rate limiting information is automatically captured and made available through the `ESIModelDTO<T>` object returned by API calls:

```csharp
var result = await eveClient.Universe.GetUniverseTypes();

// Error rate limiting
int errorsRemaining = result.RemainingErrors;
int errorResetSeconds = result.ErrorsTimeRemainingInWindowInSeconds;

// Request rate limiting
string rateLimitConfig = result.RateLimitLimit; // e.g., "150/15m"
int requestsRemaining = result.RateLimitRemaining;
int rateLimitResetSeconds = result.RateLimitReset;
```

### Best Practices

1. **Monitor rate limits**: Check the rate limiting fields in responses to avoid hitting limits
2. **Handle 420/429 errors**: If you receive these errors, wait for the appropriate reset period before retrying
3. **Implement exponential backoff**: When retrying failed requests, use exponential backoff to avoid making the situation worse
4. **Cache responses**: Use ETags and the `If-None-Match` header to avoid unnecessary requests

For more information about ESI rate limiting, see the [ESI documentation](https://developers.eveonline.com/docs/services/esi/rate-limiting/).

## Donate
Feel like donating to show appreciation for the time and effort I've put into creating and maintaining this library? Consider either becoming a GitHub Sponsor or donating ISK to ```Gehnster```
