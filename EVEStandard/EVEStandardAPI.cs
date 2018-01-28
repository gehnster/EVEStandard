using EVEStandard.Enumerations;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EVEStandard
{
    public class EVEStandardAPI
    {
        public static readonly string ESI_BASE = "https://esi.tech.ccp.is";
        private HttpClient http;

        public EVEStandardAPI(string UserAgent, DataSource dataSource, TimeSpan timeOut)
        {
            this.http = new HttpClient();
            this.http.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            this.http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            this.http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            this.http.Timeout = timeOut;
        }
    }
}
