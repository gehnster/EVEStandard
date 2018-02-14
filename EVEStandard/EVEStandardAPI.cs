using EVEStandard.API;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard
{
    public class EVEStandardAPI
    {
        
        private static HttpClient http;
        private string userAgent = "EVEStandard-non-given";
        private string dataSource = "tranquility";
        private SSO sso;

        // API
        private Alliances alliances;
        private API.Status status;
        private Assets assets;

        /// <summary>
        /// Initialize the EVEStandard Library
        /// </summary>
        /// <param name="userAgent"></param>
        /// <param name="dataSource"></param>
        /// <param name="timeOut"></param>
        public EVEStandardAPI(string userAgent, DataSource dataSource, TimeSpan timeOut)
        {
            http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", HttpUtility.UrlEncode(userAgent));
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            http.Timeout = timeOut;

            this.userAgent = userAgent ?? "EVEStandard-default";
            this.dataSource = dataSource == DataSource.Tranquility ? "tranquility" : "singularity";

            initializeAPI();
        }

        /// <summary>
        /// Initialize the EVE Standard Library with Single Sign On support.
        /// </summary>
        /// <param name="userAgent"></param>
        /// <param name="dataSource"></param>
        /// <param name="timeOut"></param>
        /// <param name="callbackUri"></param>
        /// <param name="clientId"></param>
        /// <param name="secretKey"></param>
        public EVEStandardAPI(string userAgent, DataSource dataSource, TimeSpan timeOut, string callbackUri, string clientId, string secretKey) : this(userAgent, dataSource, timeOut)
        {
            SSO.HTTP = http;
            this.sso = new SSO(callbackUri, clientId, secretKey, dataSource);
        }

        /// <summary>
        /// Test a route that is still in development.
        /// </summary>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and user agent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <returns></returns>
        public string TestDevRoute(string route)
        {
            return "";
        }

        /// <summary>
        /// Test a route that is still in development and requires authentication via SSO
        /// </summary>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and useragent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <returns></returns>
        public string TestAuthDevRoute(string route)
        {
            return "";
        }

        /// <summary>
        /// Perform SSO Authentication operations
        /// </summary>
        public SSO SSO => this.sso;

        /// <summary>
        /// Get data from the Alliances operations in ESI
        /// </summary>
        public Alliances Alliances => this.alliances;
        public API.Status Status => this.status;
        public Assets Assets => this.assets;

        private void initializeAPI()
        {
            this.alliances = new Alliances(this.dataSource)
            {
                HTTP = http
            };
            this.status = new API.Status(this.dataSource)
            {
                HTTP = http
            };
            this.assets = new Assets(this.dataSource)
            {
                HTTP = http
            };
        }
    }
}
