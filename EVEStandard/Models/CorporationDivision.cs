using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationDivision : ModelBase<CorporationDivision>
    {
        /// <summary>
        /// hangar array
        /// </summary>
        /// <value>hangar array</value>
        [JsonProperty("hangar")]
        public List<DivisionHanger> Hangar { get; set; }

        /// <summary>
        /// wallet array
        /// </summary>
        /// <value>wallet array</value>
        [JsonProperty("wallet")]
        public List<DivisionWallet> Wallet { get; set; }
    }

    public class DivisionHanger : ModelBase<DivisionHanger>
    {
        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonProperty("division")]
        public int? Division { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DivisionWallet : ModelBase<DivisionWallet>
    {
        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonProperty("division")]
        public int? Division { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
