using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using EVEStandard.API;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;

namespace EVEStandard
{
    public class EVEStandardAPI
    {

        private static HttpClient http;
        private readonly string userAgent;
        private readonly string dataSource;
        private readonly CompatibilityDate compatibilityDate;

        /// <summary>
        /// Initialize the EVEStandard Library
        /// </summary>
        /// <param name="userAgent">Please follow the user agent guidelines that CCP has provided. https://developers.eveonline.com/docs/services/esi/best-practices/#user-agents</param>
        /// <param name="dataSource"></param>
        /// <param name="compatabilityDate">The compatiblity date you want to target.</param>
        /// <param name="timeOut"></param>
        /// <param name="clientHandler"></param>
        public EVEStandardAPI(string userAgent, DataSource dataSource, CompatibilityDate compatabilityDate, TimeSpan timeOut, HttpClientHandler clientHandler = null)
        {
            if (clientHandler == null)
            { 
                clientHandler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
            }

            if (string.IsNullOrWhiteSpace(userAgent))
            {
                throw new EVEStandardException("Please follow the user agent guidelines that CCP has provided. https://developers.eveonline.com/docs/services/esi/best-practices/#user-agents");
            }

            http = new HttpClient(clientHandler);
            http.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            http.Timeout = timeOut;

            this.userAgent = userAgent;
            this.dataSource = Enum.GetName(typeof(DataSource), dataSource)?.ToLower();
            this.compatibilityDate = compatabilityDate;

            initializeAPI();
        }

        public void AddLogging(ILoggerFactory factory)
        {
            LibraryLogging.LoggerFactory = factory;
            initializeAPI();
        }

        /// <summary>
        /// Test a route that is still in development.
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="dataSource"></param>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and user agent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters, object body, string ifNoneMatch = null)
        {
            if (string.IsNullOrWhiteSpace(dataSource))
            {
                throw new ArgumentException("Argument was invalid", nameof(dataSource));
            }

            return await TestDevRoute(httpMethod, dataSource, route, queryParameters, null, body, ifNoneMatch);
        }

        /// <summary>
        /// Test a route that is still in development and requires authentication via SSO
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and useragent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <param name="httpMethod"></param>
        /// <param name="queryParameters"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters, AuthDTO auth, object body, string ifNoneMatch = null)
        {
            if (string.IsNullOrEmpty(dataSource))
            {
                throw new ArgumentException("Argument was invalid", nameof(dataSource));
            }

            var api = new APIBase(dataSource);

            APIResponse responseModel;

            switch (httpMethod.ToUpper())
            {
                case "GET":
                    responseModel = await api.GetAsync(route, auth, ifNoneMatch, queryParameters);
                    break;
                case "POST":
                    responseModel = await api.PostAsync(route, auth, body, ifNoneMatch, queryParameters);
                    break;
                case "PUT":
                    responseModel = await api.PutAsync(route, auth, body, queryParameters);
                    break;
                case "DELETE":
                    responseModel = await api.DeleteAsync(route, auth, queryParameters);
                    break;
                default:
                    throw new ArgumentException("Argument was invalid", nameof(httpMethod));
            }

            if (responseModel.Error)
            {
                throw new EVEStandardException("TestDevRoute failed");
            }

            return responseModel.JSONString;
        }

        public Alliance Alliance { get; private set; }
        public Assets Assets { get; private set; }
        public Calendar Calendar { get; private set; }
        public Character Character { get; private set; }
        public Clones Clones { get; private set; }
        public Contacts Contacts { get; private set; }
        public Contracts Contracts { get; private set; }
        public Corporation Corporation { get; private set; }
        public Dogma Dogma { get; private set; }
        public FactionWarfare FactionWarfare { get; private set; }
        public Fittings Fittings { get; private set; }
        public Fleets Fleets { get; private set; }
        public Incursions Incursion { get; private set; }
        public Industry Industry { get; private set; }
        public Insurance Insurance { get; private set; }
        public Killmails Killmails { get; private set; }
        public Location Location { get; private set; }
        public Loyalty Loyalty { get; private set; }
        public Mail Mail { get; private set; }
        public Market Market { get; private set; }
        public Meta Meta { get; private set; }
        public PlanetaryInteraction PlanetaryInteraction { get; private set; }
        public Routes Routes { get; private set; }
        public Search Search { get; private set; }
        public Skills Skills { get; private set; }
        public Sovereignty Sovereignty { get; private set; }
        public Status Status { get; private set; }
        public Universe Universe { get; private set; }
        public UserInterface UserInterface { get; private set; }
        public Wallet Wallet { get; private set; }
        public Wars Wars { get; private set; }

        // ReSharper disable once InconsistentNaming
        private void initializeAPI()
        {
            Alliance = new Alliance(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Assets = new Assets(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Calendar = new Calendar(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Character = new Character(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Clones = new Clones(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Contacts = new Contacts(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Contracts = new Contracts(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Corporation = new Corporation(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Dogma = new Dogma(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            FactionWarfare = new FactionWarfare(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Fittings = new Fittings(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Fleets = new Fleets(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Incursion = new Incursions(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Industry = new Industry(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Insurance = new Insurance(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Killmails = new Killmails(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Location = new Location(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Loyalty = new Loyalty(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Mail = new Mail(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Market = new Market(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Meta = new Meta(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            PlanetaryInteraction = new PlanetaryInteraction(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Routes = new Routes(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Search = new Search(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Skills = new Skills(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Sovereignty = new Sovereignty(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Status = new Status(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Universe = new Universe(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            UserInterface = new UserInterface(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Wallet = new Wallet(dataSource, compatibilityDate)
            {
                HTTP = http
            };
            Wars = new Wars(dataSource, compatibilityDate)
            {
                HTTP = http
            };
        }
    }
}
