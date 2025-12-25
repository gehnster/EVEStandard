using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard.API
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class APIBase
    {
        private static HttpClient http;
        private static readonly ILogger logger = LibraryLogging.CreateLogger<APIBase>();
        private static string TRANQUILITY_ESI_BASE = "https://esi.evetech.net";
        private static string SERENITY_ESI_BASE = "https://esi.evepc.163.com";

        public readonly string ESI_BASE;
        private readonly string dataSource;
        private readonly string compatibilityDate;
        internal HttpClient HTTP { get => http; set => http = value; }

        internal APIBase(string dataSource, CompatibilityDate compatibilityDate)
        {
            this.dataSource = dataSource ?? "tranquility";
            this.ESI_BASE = this.dataSource == "serenity" ? SERENITY_ESI_BASE : TRANQUILITY_ESI_BASE;

            // Convert the CompatibilityDate enum to a string.
            // This uses the enum member name and replaces underscores with hyphens so
            // members like `v2018_07_18` -> "v2018-07-18" or `2018_07_18` -> "2018-07-18".
            // If you need a different mapping (e.g. drop a leading 'v' or use explicit values),
            // replace this with an explicit switch mapping.
            var enumName = Enum.GetName(typeof(CompatibilityDate), compatibilityDate);
            if (string.IsNullOrEmpty(enumName))
            {
                throw new ArgumentOutOfRangeException(nameof(compatibilityDate), "Invalid CompatibilityDate value");
            }

            // Remove leading 'v' or 'V'
            if ((enumName.Length > 0) && (enumName[0] == 'v' || enumName[0] == 'V'))
            {
                enumName = enumName.Substring(1);
            }

            this.compatibilityDate = enumName.Replace('_', '-');
        }

        internal async Task<APIResponse> GetAsync(string uri, string ifNoneMatch=null, Dictionary<string, string> queryParameters = null)
        {
            return await GetAsync(uri, null, ifNoneMatch, queryParameters);
        }

        internal async Task<APIResponse> GetAsync(string uri, AuthDTO auth, string ifNoneMatch=null, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Get, uri, auth, ifNoneMatch, queryParameters);
        }

        internal async Task<APIResponse> PostAsync(string uri, object body, string ifNoneMatch = null, Dictionary<string, string> queryParameters = null)
        {
            return await PostAsync(uri, null, body, ifNoneMatch, queryParameters);
        }

        internal async Task<APIResponse> PostAsync(string uri, AuthDTO auth, object body, string ifNoneMatch=null, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Post, uri, auth, ifNoneMatch, queryParameters, body);
        }

        internal async Task<APIResponse> PutAsync(string uri, AuthDTO auth, object body, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Put, uri, auth, null, queryParameters, body);
        }

        internal async Task<APIResponse> DeleteAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Delete, uri, auth, null, queryParameters);
        }

        private async Task<APIResponse> RequestAsync(HttpMethod method, string uri, AuthDTO auth, string ifNoneMatch=null, Dictionary<string, string> queryParameters = null, object body = null)
        {
            var queryParams = HttpUtility.ParseQueryString(String.Empty);

            if (queryParameters != null)
            {
                foreach (var query in queryParameters)
                {
                    queryParams.Add(query.Key, query.Value);
                }
            }
            
            try
            {
                var builder = new UriBuilder(ESI_BASE)
                {
                    Path = uri,
                    Query = queryParams.ToString()
                };

                var request = new HttpRequestMessage
                {
                    RequestUri = builder.Uri,
                    Method = method
                };
                if ((method == HttpMethod.Post || method == HttpMethod.Put) && body != null)
                {
                    request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                }
                if (auth?.AccessToken != null)
                {
                    if (auth.AccessToken.ExpiresUtc > DateTime.UtcNow)
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken.AccessToken);
                    }
                    else
                    {
                        throw new EVEStandardAuthExpiredException();
                    }
                }

                if (ifNoneMatch != null)
                {
                    request.Headers.Add("If-None-Match", ifNoneMatch);
                }

                request.Headers.Add("X-Tenant", dataSource);
                request.Headers.Add("X-Compatibility-Date", compatibilityDate);

                var authResponse = await HTTP.SendAsync(request).ConfigureAwait(false);

                return await ProcessResponse(authResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected static void CheckAuth(AuthDTO auth, string scope)
        {
            if (auth?.AccessToken?.AccessToken == null || auth.CharacterId == 0 || scope == null || auth.Scopes == null)
            {
                throw new ArgumentNullException();
            }

            if (!auth.Scopes.Contains(scope))
            {
                throw new EVEStandardScopeNotAcquired("Missing scope: " + scope);
            }
        }

        private static async Task<APIResponse> ProcessResponse(HttpResponseMessage response)
        {
            var model = new APIResponse();

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.Created)
            {
                return await ProcessSuccess(response, model);
            }
            if (response.IsSuccessStatusCode)
            {
                logger.LogWarning($"A success status code is being returned that wasn't expected. Trying to process the success. Status Code: {response.StatusCode}");
                return await ProcessSuccess(response, model);
            }
            switch (response.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.RequestTimeout:
                    model.Error = true;
                    model.Message = await response.Content.ReadAsStringAsync();
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
                case HttpStatusCode.Unauthorized:
                    throw new EVEStandardUnauthorizedException();
                case (HttpStatusCode)429:
                    model.Error = true;
                    model.Message = "Rate limit exceeded for this endpoint group. Too many tokens consumed from the rate limit bucket. Check RateLimitGroup and respect the Retry-After period before retrying.";
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
                case (HttpStatusCode)520:
                    model.Error = true;
                    model.Message = "Internal error thrown by EVE server (status 520).";
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
                case HttpStatusCode.Forbidden:
                    throw new EVEStandardScopeNotAcquired(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.NotModified:
                    model.NotModified = true;
                    model = GetExpiresAndLastModified(response, model);
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
                case (HttpStatusCode)422:
                    model.Error = true;
                    model.Message = $"Your request was invalid. Returned message: {await response.Content.ReadAsStringAsync()}";
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
                default:
                    logger.LogWarning($"API Response Issue. Status Code: {response.StatusCode}");
                    model.Error = true;
                    model.Message = $"An error code we didn't handle was returned. Status Code: {response.StatusCode}";
                    model = PopulateRateLimitHeaders(response, model);

                    return model;
            }
        }

        private static async Task<APIResponse> ProcessSuccess(HttpResponseMessage response, APIResponse model)
        {
            if (response.Headers.TryGetValues("warning", out var warningValues))
            {
                model.LegacyWarning = true;
                model.Message = String.Join(", ", warningValues);
            }
            try
            {
                model = GetExpiresAndLastModified(response, model);
                model = PopulateRateLimitHeaders(response, model);

                if (response.Headers.TryGetValues("X-Pages", out var xPagesEnumerable))
                {
                    model.MaxPages = int.TryParse(xPagesEnumerable.FirstOrDefault(), out var xPages) ? xPages : 1;
                }
                if (response.Headers.TryGetValues("Content-Language", out var language))
                {
                    model.Language = language.FirstOrDefault();
                }
                if (response.Headers.TryGetValues("ETag", out var eTag))
                {
                    model.ETag = eTag.FirstOrDefault();
                }

                // Check whether response is compressed
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return model;
                }

                if (response.Content.Headers.ContentEncoding.Any(x => x == "gzip"))
                {
                    // Decompress manually
                    using (var s = await response.Content.ReadAsStreamAsync())
                    {
                        using (var decompressed = new GZipStream(s, CompressionMode.Decompress))
                        {
                            using (var rdr = new StreamReader(decompressed))
                            {
                                model.JSONString = await rdr.ReadToEndAsync();
                            }
                        }
                    }
                }
                else
                {
                    model.JSONString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                // Parse cursor-based pagination info if present
                model = ParseCursorInfo(model);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static APIResponse GetExpiresAndLastModified(HttpResponseMessage response, APIResponse model)
        {
            model.Expires = response.Content.Headers.Expires;
            model.LastModified = response.Content.Headers.LastModified;

            return model;
        }

        private static int GetHeaderValueAsInt(HttpResponseMessage response, string headerName, int defaultValue = 0)
        {
            if (response.Headers.TryGetValues(headerName, out var values))
            {
                var firstValue = values.FirstOrDefault();
                if (int.TryParse(firstValue, out var result))
                {
                    return result;
                }
            }
            return defaultValue;
        }

        private static APIResponse PopulateRateLimitHeaders(HttpResponseMessage response, APIResponse model)
        {
            // Rate limiting headers (floating window token bucket system)
            if (response.Headers.TryGetValues("X-Ratelimit-Group", out var groupValues))
            {
                model.RateLimitGroup = groupValues.FirstOrDefault();
            }
            if (response.Headers.TryGetValues("X-Ratelimit-Limit", out var limitValues))
            {
                model.RateLimitLimit = limitValues.FirstOrDefault();
            }
            model.RateLimitRemaining = GetHeaderValueAsInt(response, "X-Ratelimit-Remaining");
            model.RateLimitUsed = GetHeaderValueAsInt(response, "X-Ratelimit-Used");
            
            // Retry-After is only present in 429 responses
            model.RetryAfter = GetHeaderValueAsInt(response, "Retry-After");
            
            return model;
        }

        private static APIResponse ParseCursorInfo(APIResponse model)
        {
            // Try to parse cursor information from the JSON response
            // Cursor-based pagination responses include a "cursor" field with "before" and "after" tokens
            if (!string.IsNullOrEmpty(model.JSONString))
            {
                try
                {
                    using (var document = JsonDocument.Parse(model.JSONString))
                    {
                        if (document.RootElement.TryGetProperty("cursor", out var cursorElement))
                        {
                            model.Cursor = JsonSerializer.Deserialize<CursorInfo>(cursorElement.GetRawText());
                        }
                    }
                }
                catch
                {
                    // If parsing fails, cursor stays null - this is fine for non-cursor paginated endpoints
                }
            }
            
            return model;
        }

        internal static void CheckResponse(string functionName, bool error, string errorMessage, bool legacyWarning, ILogger _logger)
        {
            if (error)
            {
                _logger.LogError("{0} returned with this error: {1}", functionName, errorMessage);
                throw new EVEStandardException($"Unhandled error: {errorMessage}");
            }
            if (legacyWarning)
            {
                _logger.LogWarning("{0} is a legacy end-point and could disappear soon, considering moving to a newer end-point.", functionName);
            }
        }

        protected ESIModelDTO<T> ReturnModelDTO<T>(APIResponse response)
        {
            // Build a sensible empty instance for T when response.JSONString is null/empty.
            // Attempt deserializing an empty object first (fills defaults), then fall back to Activator,
            // and finally to default(T).
            T modelInstance;
            if (string.IsNullOrEmpty(response.JSONString))
            {
                try
                {
                    modelInstance = JsonSerializer.Deserialize<T>("{}");
                }
                catch
                {
                    try
                    {
                        modelInstance = Activator.CreateInstance<T>();
                    }
                    catch
                    {
                        modelInstance = default(T);
                    }
                }
            }
            else
            {
                modelInstance = JsonSerializer.Deserialize<T>(response.JSONString);
            }

            return new ESIModelDTO<T>()
            {
                NotModified = response.NotModified,
                ETag = response.ETag,
                Language = response.Language,
                Expires = response.Expires,
                LastModified = response.LastModified,
                MaxPages = response.MaxPages,
                Model = modelInstance,
                // Rate limiting
                RateLimitGroup = response.RateLimitGroup,
                RateLimitLimit = response.RateLimitLimit,
                RateLimitRemaining = response.RateLimitRemaining,
                RateLimitUsed = response.RateLimitUsed,
                RetryAfter = response.RetryAfter,
                // Cursor-based pagination
                Cursor = response.Cursor
            };
        }
    }
}