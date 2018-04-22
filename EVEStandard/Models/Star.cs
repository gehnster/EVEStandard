using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EveCorpMonNet.Libraries.EVEStandard.Enumerations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Star : ModelBase<Star>
    {
        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [Required]
        [JsonProperty("solar_system_id")]
        public int? SolarSystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [Required]
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// Age of star in years
        /// </summary>
        /// <value>Age of star in years</value>
        [Required]
        [JsonProperty("age")]
        public long? Age { get; set; }

        /// <summary>
        /// luminosity number
        /// </summary>
        /// <value>luminosity number</value>
        [Required]
        [JsonProperty("luminosity")]
        public float? Luminosity { get; set; }

        /// <summary>
        /// radius integer
        /// </summary>
        /// <value>radius integer</value>
        [Required]
        [JsonProperty("radius")]
        public long? Radius { get; set; }
        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        

        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        [Required]
        [JsonProperty("spectral_class")]
        public SpectralClassEnum? SpectralClass { get; set; }

        /// <summary>
        /// temperature integer
        /// </summary>
        /// <value>temperature integer</value>
        [Required]
        [JsonProperty("temperature")]
        public int? Temperature { get; set; }
    }
}
