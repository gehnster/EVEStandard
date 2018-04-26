using EVEStandard.API;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            this.initializeAPI();
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
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters)
        {
            return await this.TestDevRoute(httpMethod, dataSource, route, queryParameters, null);
        }

        /// <summary>
        /// Test a route that is still in development and requires authentication via SSO
        /// </summary>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and useragent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <returns></returns>
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters, AuthDTO auth)
        {
            var api = new APIBase(dataSource);

            APIResponse responseModel;

            if(httpMethod.ToUpper() == "GET")
            {
                responseModel = await api.GetAsync(route, auth, queryParameters);
            }
            else if(httpMethod.ToUpper() == "POST")
            {
                responseModel = await api.PostAsync(route, auth, queryParameters);
            }
            else if (httpMethod.ToUpper() == "PUT")
            {
                responseModel = await api.PutAsync(route, auth, queryParameters);
            }
            else
            {
                responseModel = await api.DeleteAsync(route, auth, queryParameters);
            }

            if (responseModel.Error)
            {
                throw new EVEStandardException("TestDevRoute failed");
            }

            return responseModel.JSONString;
        }

        /// <summary>
        /// Perform SSO Authentication operations
        /// </summary>
        public SSO SSO => this.sso;

        /// <summary>
        /// Get data from the Alliances operations in ESI
        /// </summary>
        public Alliances Alliances { get; private set; }
        public Assets Assets { get; private set; }
        public Bookmarks Bookmarks { get; private set; }
        public Calendar Calendar { get; private set; }
        public Character Character { get; private set; }
        public API.Clones Clones { get; private set; }
        public Contacts Contacts { get; private set; }
        public Contracts Contracts { get; private set; }
        public Corporation Corporation { get; private set; }
        public Dogma Dogma { get; private set; }
        public FactionWarfare FactionWarfare { get; private set; }
        public Fittings Fittings { get; private set; }
        public Fleets Fleets { get; private set; }
        public API.Incursion Incursion { get; private set; }
        public Industry Industry { get; private set; }
        public Insurance Insurance { get; private set; }
        public Killmails Killmails { get; private set; }
        public API.Location Location { get; private set; }
        public Loyalty Loyalty { get; private set; }
        public API.Mail Mail { get; private set; }
        public Market Market { get; private set; }
        public Opportunities Opportunities { get; private set; }
        public PlanetaryInteraction PlanetaryInteraction { get; private set; }
        public Routes Routes { get; private set; }
        public API.Search Search { get; private set; }
        public Skills Skills { get; private set; }
        public Sovereignty Sovereignty { get; private set; }
        public API.Status Status { get; private set; }
        public Universe Universe { get; private set; }
        public UserInterface UserInterface { get; private set; }
        public Wallet Wallet { get; private set; }
        public Wars Wars { get; private set; }

        private void initializeAPI()
        {
            this.Alliances = new Alliances(this.dataSource)
            {
                HTTP = http
            };
            this.Assets = new Assets(this.dataSource)
            {
                HTTP = http
            };
            this.Bookmarks = new Bookmarks(this.dataSource)
            {
                HTTP = http
            };
            this.Calendar = new Calendar(this.dataSource)
            {
                HTTP = http
            };
            this.Character = new Character(this.dataSource)
            {
                HTTP = http
            };
            this.Clones = new API.Clones(this.dataSource)
            {
                HTTP = http
            };
            this.Contacts = new Contacts(this.dataSource)
            {
                HTTP = http
            };
            this.Contracts = new Contracts(this.dataSource)
            {
                HTTP = http
            };
            this.Corporation = new Corporation(this.dataSource)
            {
                HTTP = http
            };
            this.Dogma = new Dogma(this.dataSource)
            {
                HTTP = http
            };
            this.FactionWarfare = new FactionWarfare(this.dataSource)
            {
                HTTP = http
            };
            this.Fittings = new Fittings(this.dataSource)
            {
                HTTP = http
            };
            this.Fleets = new Fleets(this.dataSource)
            {
                HTTP = http
            };
            this.Incursion = new API.Incursion(this.dataSource)
            {
                HTTP = http
            };
            this.Industry = new Industry(this.dataSource)
            {
                HTTP = http
            };
            this.Insurance = new Insurance(this.dataSource)
            {
                HTTP = http
            };
            this.Killmails = new Killmails(this.dataSource)
            {
                HTTP = http
            };
            this.Location = new API.Location(this.dataSource)
            {
                HTTP = http
            };
            this.Loyalty = new Loyalty(this.dataSource)
            {
                HTTP = http
            };
            this.Mail = new API.Mail(this.dataSource)
            {
                HTTP = http
            };
            this.Market = new Market(this.dataSource)
            {
                HTTP = http
            };
            this.Opportunities = new Opportunities(this.dataSource)
            {
                HTTP = http
            };
            this.PlanetaryInteraction = new PlanetaryInteraction(this.dataSource)
            {
                HTTP = http
            };
            this.Routes = new Routes(this.dataSource)
            {
                HTTP = http
            };
            this.Search = new API.Search(this.dataSource)
            {
                HTTP = http
            };
            this.Skills = new Skills(this.dataSource)
            {
                HTTP = http
            };
            this.Sovereignty = new Sovereignty(this.dataSource)
            {
                HTTP = http
            };
            this.Status = new API.Status(this.dataSource)
            {
                HTTP = http
            };
            this.Universe = new Universe(this.dataSource)
            {
                HTTP = http
            };
            this.UserInterface = new UserInterface(this.dataSource)
            {
                HTTP = http
            };
            this.Wallet = new Wallet(this.dataSource)
            {
                HTTP = http
            };
            this.Wars = new Wars(this.dataSource)
            {
                HTTP = http
            };
        }
    }
}
