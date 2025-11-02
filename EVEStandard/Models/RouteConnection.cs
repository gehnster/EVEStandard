using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class RouteConnection : ModelBase<RouteConnection>
    {
        #region Properties
        [JsonPropertyName("from")]
        public long From { get; set; }
        [JsonPropertyName("to")]
        public long To { get; set; }
        #endregion Properties
    }
}
