using EVEStandard.Models.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard.API
{
    public class APIBase
    {
        private static HttpClient http;
        private string dataSource;

        public static readonly string ESI_BASE = "https://esi.tech.ccp.is";

        internal HttpClient HTTP { get => http; set => http = value; }

        internal APIBase(string dataSource)
        {
            this.dataSource = dataSource ?? "tranquility";
        }

        internal async Task<APIResponse> GetAsync(string uri, Dictionary<string, string> queryParameters = null)
        {
            return await GetAsync(uri, null, queryParameters);
        }

        internal async Task<APIResponse> GetAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Get, uri, auth, queryParameters);
        }

        internal async Task<APIResponse> PostAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Post, uri, auth, queryParameters);
        }

        internal async Task<APIResponse> PutAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Put, uri, auth, queryParameters);
        }

        internal async Task<APIResponse> DeleteAsync(string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
        {
            return await RequestAsync(HttpMethod.Delete, uri, auth, queryParameters);
        }

        internal async Task<APIResponse> RequestAsync(HttpMethod method, string uri, AuthDTO auth, Dictionary<string, string> queryParameters = null)
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
                if (auth != null && auth.AccessToken != null)
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

                return await processResponse(authResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

            protected void checkAuth(AuthDTO auth, string scope)
        {
            if (auth == null || auth.Character == null || auth.AccessToken == null)
            {
                throw new ArgumentNullException();
            }

            if (!auth.Character.Scopes.Contains(scope))
            {
                // throw same standard exception or a new no scope exception?
            }
        }

        private async Task<APIResponse> processResponse(HttpResponseMessage response)
        {
            var model = new APIResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await processSuccess(response, model);
            }
            else if (response.IsSuccessStatusCode)
            {
                throw new EVEStandardException("Success Status Code not handled in GetNoAuthAsync, StatusCode: " + response.StatusCode);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                model.Error = true;
                model.Message = await response.Content.ReadAsStringAsync();

                return model;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                model.Error = true;
                model.Message = await response.Content.ReadAsStringAsync();

                return model;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                model.Error = true;
                model.Message = "Too many requests made to ESI in a short period of time";

                return model;
            }
            else
            {
                throw new EVEStandardException("API Response Issue");
            }
        }

        private async Task<APIResponse> processSuccess(HttpResponseMessage response, APIResponse model)
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
                    foreach (var value in expiresEnumerable)
                    {
                        model.Expires = DateTime.TryParse(value, out var expires) ? expires : DateTime.UtcNow;
                    }
                }
                if (response.Headers.TryGetValues("last-modified", out var lastModifiedEnumerable))
                {
                    foreach (var value in lastModifiedEnumerable)
                    {
                        model.LastModified = DateTime.TryParse(value, out var lastModified) ? lastModified : DateTime.UtcNow;
                    }
                }

                // Check whether response is compressed
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

                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
