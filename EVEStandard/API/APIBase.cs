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
            this.dataSource = dataSource;
        }

        internal async Task<APIResponse> GetNoAuthAsync(string uri)
        {
            var noAuthResponse = await this.HTTP.GetAsync(uri + "/?datasource=" + this.dataSource);

            return await processResponse(noAuthResponse);
        }

        private async Task<APIResponse> processResponse(HttpResponseMessage response)
        {
            var model = new APIResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Headers.Contains("warning"))
                {
                    model.LegacyWarning = true;
                    model.Message = response.Headers.Warning.ToString();
                }
                if (response.Headers.Contains("expires"))
                {
                    model.Expires = DateTime.Parse(response.Headers.GetValues("expires").ToString());
                }
                if (response.Headers.Contains("last-modified"))
                {
                    model.LastModified = DateTime.Parse(response.Headers.GetValues("last-modified").ToString());
                }
                model.JSONString = await response.Content.ReadAsStringAsync();

                return model;
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
                throw new EVEStandardException("API Get Failed");
            }
        }
    }
}
