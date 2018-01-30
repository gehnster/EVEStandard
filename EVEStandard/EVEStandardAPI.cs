using EVEStandard.Enumerations;
using EVEStandard.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EVEStandard
{
    public class EVEStandardAPI
    {
        public static readonly string ESI_BASE = "https://esi.tech.ccp.is";
        private static HttpClient http;
        internal string UserAgent = "EVEStandard default";
        internal string dataSource = "tranquility";

        public EVEStandardAPI(string UserAgent, DataSource dataSource, TimeSpan timeOut)
        {
            http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            http.Timeout = timeOut;

            this.UserAgent = UserAgent;
            this.dataSource = dataSource == DataSource.Tranquility ? "tranquility" : "singularity";
        }

        public async Task<Status> GetStatus()
        {
            var noAuthResponse = await http.GetAsync(ESI_BASE + "/latest/status/?datasource=" + this.dataSource + "&user_agent=" + this.UserAgent);

            return JsonConvert.DeserializeObject<Status>(noAuthResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
