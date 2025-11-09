using EVEStandard.Enumerations;
using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class UniverseIdsToNames : ModelBase<UniverseIdsToNames>
    {
        #region Properties

        /// <summary>
        /// category string
        /// </summary>
        /// <value>category string</value>
        [JsonPropertyName("category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets the Category as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public CategoryEnum CategoryToEnum 
        {
            get => (CategoryEnum)Enum.Parse(typeof(CategoryEnum), Category);
        }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
