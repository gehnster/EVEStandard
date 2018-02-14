using EVEStandard.Models.API;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        internal async Task<APIResponse> GetNoAuthAsync(string uri)
        {
            try
            {
                var noAuthResponse = await this.HTTP.GetAsync(uri + "/?datasource=" + this.dataSource).ConfigureAwait(false);

                return await processResponse(noAuthResponse);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private async Task<APIResponse> processResponse(HttpResponseMessage response)
        {
            var model = new APIResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Headers.Contains("warning"))
                {
                    model.LegacyWarning = true;
                    model.Message = response.Headers.Warning.Count == 1 ? response.Headers.Warning.ToString() : throw new EVEStandardException("Expected one warning header, but got " + response.Headers.Warning.Count + " instead");
                }
                try
                {
                    if (response.Headers.Contains("expires"))
                    {
                        foreach(var value in response.Headers.GetValues("expires"))
                        {
                            model.Expires = DateTime.TryParse(value, out var expires) ? expires : DateTime.UtcNow;
                        }
                    }
                    if (response.Headers.Contains("last-modified"))
                    {
                        foreach (var value in response.Headers.GetValues("last-modified"))
                        {
                            model.LastModified = DateTime.TryParse(value, out var lastModified) ? lastModified : DateTime.UtcNow;
                        }
                    }
                    model.JSONString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return model;
                }
                catch(Exception)
                {
                    throw;
                }
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
    }
}
