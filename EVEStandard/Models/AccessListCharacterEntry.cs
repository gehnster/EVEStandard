using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListCharacterEntry : ModelBase<AccessListCharacterEntry>
    {
        #region Properties

        /// <summary>
        /// Character's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.
        /// </summary>
        /// <value>Character's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.</value>
        [JsonPropertyName("access")]
        public string Access { get; set; }

        /// <summary>
        /// Character's ID
        /// </summary>
        /// <value>Character's ID</value>
        [JsonPropertyName("character_id")]
        public long CharacterId { get; set; }

        #endregion Properties
    }
}
