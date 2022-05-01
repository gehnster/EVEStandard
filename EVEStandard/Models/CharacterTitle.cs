using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterTitle : ModelBase<CharacterTitle>
    {
        #region Properties

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// title_id integer
        /// </summary>
        /// <value>title_id integer</value>
        [JsonPropertyName("title_id")]
        public int? TitleId { get; set; }

        #endregion Properties
    }
}
