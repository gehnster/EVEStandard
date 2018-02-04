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

        internal async Task<string> GetNoAuthAsync(string uri)
        {
            var noAuthResponse = await this.HTTP.GetAsync(uri + "/?datasource=" + this.dataSource);

            if(noAuthResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await noAuthResponse.Content.ReadAsStringAsync();
            }
            else if(noAuthResponse.IsSuccessStatusCode)
            {
                throw new EVEStandardException("Success Status Code not handled in GetNoAuthAsync, StatusCode: " + noAuthResponse.StatusCode);
            }
            else if(noAuthResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                // change returned for a model that supports the expected string or an error with a string response with the error.
            }
            else
            {
                throw new EVEStandardException("API Get Failed");
            }
        }
    }
}
