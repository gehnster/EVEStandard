using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard.API
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class APIBase
    {
        private static HttpClient http;
        private readonly string dataSource;

        public static readonly string ESI_BASE = "https://esi.tech.ccp.is";

        internal HttpClient HTTP { get => http; set => http = value; }

        internal APIBase(string dataSource)
        {
            this.dataSource = dataSource ?? "tranquility";
        }

        internal async Task<APIResponse> GetAsync(string uri, Dictionary<string, string> queryParameters = null)
        {
            return await this.GetAsync(uri, null, queryParameters);
        }

        internal async Task<APIResponse> GetAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await this.RequestAsync(HttpMethod.Get, uri, auth, queryParameters);
        }

        internal async Task<APIResponse> PostAsync(string uri, AuthDTO auth, object body, Dictionary<string, string> queryParameters = null)
        {
            return await this.RequestAsync(HttpMethod.Post, uri, auth, queryParameters, body);
        }

        internal async Task<APIResponse> PutAsync(string uri, AuthDTO auth, object body, Dictionary<string, string> queryParameters = null)
        {
            return await this.RequestAsync(HttpMethod.Put, uri, auth, queryParameters, body);
        }

        internal async Task<APIResponse> DeleteAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await this.RequestAsync(HttpMethod.Delete, uri, auth, queryParameters);
        }

        private async Task<APIResponse> RequestAsync(HttpMethod method, string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null, object body = null)
        {
            var queryParams = "?datasource=" + this.dataSource;

            if (queryParameters != null && queryParameters.Count > 0)
            {
                foreach (var query in queryParameters)
                {
                    if (query.Key == "page")
                    {
                        queryParams += "&page=" + HttpUtility.UrlEncode(query.Value);
                    }
                    else
                    {
                        throw new EVEStandardException("Query parameter not handled: " + query.Key + " value: " + query.Value);
                    }
                }
            }
            
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(ESI_BASE + uri + queryParams),
                    Method = method
                };
                if((method == HttpMethod.Post || method == HttpMethod.Put) && body != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                }
                if (auth?.AccessToken != null)
                {
                    if (auth.AccessToken.Expires > DateTime.UtcNow)
                    {
                        request.Headers.Add("token", auth.AccessToken.AccessToken);
                    }
                    else
                    {
                        throw new EVEStandardAuthExpiredException();
                    }
                }

                var authResponse = await this.HTTP.SendAsync(request).ConfigureAwait(false);

                return await this.processResponse(authResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected static void checkAuth(AuthDTO auth, string scope)
        {
            if (auth?.Character == null || auth.AccessToken == null)
            {
                throw new ArgumentNullException();
            }

            if (!auth.Character.Scopes.Contains(scope))
            {
                throw new EVEStandardScopeNotAcquired("Missing scope: " + scope);
            }
        }

        private async Task<APIResponse> processResponse(HttpResponseMessage response)
        {
            var model = new APIResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return await processSuccess(response, model);
            }
            if (response.IsSuccessStatusCode)
            {
                throw new EVEStandardException("Success Status Code not handled in GetNoAuthAsync, StatusCode: " + response.StatusCode);
            }
            switch (response.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    model.Error = true;
                    model.Message = await response.Content.ReadAsStringAsync();

                    return model;
                case HttpStatusCode.NotFound:
                    model.Error = true;
                    model.Message = await response.Content.ReadAsStringAsync();

                    return model;
                case HttpStatusCode.Conflict:
                    model.Error = true;
                    model.Message = "Too many requests made to ESI in a short period of time";

                    return model;
                case HttpStatusCode.Forbidden:
                    model.Error = true;
                    model.Message = "You don't have the required SSO scope most likely.";

                    return model;
                default:
                    throw new EVEStandardException("API Response Issue. Status Code: " + response.StatusCode);
            }
        }

        private static async Task<APIResponse> processSuccess(HttpResponseMessage response, APIResponse model)
        {
            if (response.Headers.Contains("warning"))
            {
                model.LegacyWarning = true;
                model.Message = response.Headers.Warning.Count == 1 ? response.Headers.Warning.ToString() : throw new EVEStandardException("Expected one warning header, but got " + response.Headers.Warning.Count + " instead");
            }
            try
            {
                if (response.Headers.TryGetValues("expires", out var expiresEnumerable))
                {
                    model.Expires = DateTime.TryParse(expiresEnumerable.FirstOrDefault(), out var expires) ? expires : DateTime.UtcNow;
                }
                if (response.Headers.TryGetValues("last-modified", out var lastModifiedEnumerable))
                {
                    model.LastModified = DateTime.TryParse(lastModifiedEnumerable.FirstOrDefault(), out var lastModified) ? lastModified : DateTime.UtcNow;
                }
                if (response.Headers.TryGetValues("X-Pages", out var xPagesEnumerable))
                {
                    model.MaxPages = long.TryParse(xPagesEnumerable.FirstOrDefault(), out var xPages) ? xPages : 1;
                }
                if (response.Headers.TryGetValues("Content-Language", out var language))
                {
                    model.Language = language.FirstOrDefault();
                }

                // Check whether response is compressed
                if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
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
                }

                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void checkResponse(string functionName, bool error, bool legacyWarning, ILogger logger)
        {
            if (error)
            {
                throw new EVEStandardException(functionName + " failed");
            }
            if (legacyWarning)
            {
                logger.LogWarning("{0} is a legacy end-point and could disappear soon, considering moving to a newer end-point.", functionName);
            }
        }
    }
}
