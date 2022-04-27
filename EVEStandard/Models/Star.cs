using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Star : ModelBase<Star>
    {
        #region Properties

        /// <summary>
        /// Age of star in years
        /// </summary>
        /// <value>Age of star in years</value>
        [JsonPropertyName("age")]
        public long Age { get; set; }

        /// <summary>
        /// luminosity number
        /// </summary>
        /// <value>luminosity number</value>
        [JsonPropertyName("luminosity")]
        public float Luminosity { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// radius integer
        /// </summary>
        /// <value>radius integer</value>
        [JsonPropertyName("radius")]
        public long Radius { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        [JsonPropertyName("spectral_class")]
        public string SpectralClass { get; set; }

        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        /// <summary>
        /// temperature integer
        /// </summary>
        /// <value>temperature integer</value>
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
