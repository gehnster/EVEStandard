using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class DogmaAttribute : ModelBase<DogmaAttribute>
    {
        #region Properties

        /// <summary>
        /// attribute_id integer
        /// </summary>
        /// <value>attribute_id integer</value>
        [JsonPropertyName("attribute_id")]
        public int AttributeId { get; set; }

        /// <summary>
        /// default_value number
        /// </summary>
        /// <value>default_value number</value>
        [JsonPropertyName("default_value")]
        public float? DefaultValue { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// display_name string
        /// </summary>
        /// <value>display_name string</value>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// high_is_good boolean
        /// </summary>
        /// <value>high_is_good boolean</value>
        [JsonPropertyName("high_is_good")]
        public bool? HighIsGood { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonPropertyName("icon_id")]
        public int? IconId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }
        /// <summary>
        /// stackable boolean
        /// </summary>
        /// <value>stackable boolean</value>
        [JsonPropertyName("stackable")]
        public bool? Stackable { get; set; }

        /// <summary>
        /// unit_id integer
        /// </summary>
        /// <value>unit_id integer</value>
        [JsonPropertyName("unit_id")]
        public int? UnitId { get; set; }

        #endregion Properties
    }
}
