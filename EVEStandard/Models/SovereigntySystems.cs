using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntySystems : ModelBase<SovereigntySystems>
    {
        #region Properties

        /// <summary>
        /// List of solar systems and their sovereignty owners
        /// </summary>
        /// <value>List of solar systems and their sovereignty owners</value>
        [JsonPropertyName("solar_systems")]
        public List<SovereigntySystem> SolarSystems { get; set; }

        #endregion Properties
    }
}
