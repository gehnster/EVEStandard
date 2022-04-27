using System;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class ContainerLogs : ModelBase<ContainerLogs>
    {
        #region Enums

        /// <summary>
        /// Type of password set if action is of type SetPassword or EnterPassword
        /// </summary>
        /// <value>Type of password set if action is of type SetPassword or EnterPassword</value>
        public enum PasswordTypeEnum
        {
            config = 1,
            general = 2
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// action string
        /// </summary>
        /// <value>action string</value>
        [JsonPropertyName("action")]
        public ActionEnum Action { get; set; }

        /// <summary>
        /// ID of the character who performed the action.
        /// </summary>
        /// <value>ID of the character who performed the action.</value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// ID of the container
        /// </summary>
        /// <value>ID of the container</value>
        [JsonPropertyName("container_id")]
        public long ContainerId { get; set; }

        /// <summary>
        /// Type ID of the container
        /// </summary>
        /// <value>Type ID of the container</value>
        [JsonPropertyName("container_type_id")]
        public int ContainerTypeId { get; set; }

        /// <summary>
        /// location_flag string
        /// </summary>
        /// <value>location_flag string</value>
        [JsonPropertyName("location_flag")]
        public LocationFlag LocationFlag { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonPropertyName("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// Timestamp when this log was created
        /// </summary>
        /// <value>Timestamp when this log was created</value>
        [JsonPropertyName("logged_at")]
        public DateTime LoggedAt { get; set; }
        /// <summary>
        /// new_config_bitmask integer
        /// </summary>
        /// <value>new_config_bitmask integer</value>
        [JsonPropertyName("new_config_bitmask")]
        public int? NewConfigBitmask { get; set; }

        /// <summary>
        /// old_config_bitmask integer
        /// </summary>
        /// <value>old_config_bitmask integer</value>
        [JsonPropertyName("old_config_bitmask")]
        public int? OldConfigBitmask { get; set; }

        /// <summary>
        /// Type of password set if action is of type SetPassword or EnterPassword
        /// </summary>
        /// <value>Type of password set if action is of type SetPassword or EnterPassword</value>
        [JsonPropertyName("password_type")]
        public PasswordTypeEnum? PasswordType { get; set; }

        /// <summary>
        /// Quantity of the item being acted upon
        /// </summary>
        /// <value>Quantity of the item being acted upon</value>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Type ID of the item being acted upon
        /// </summary>
        /// <value>Type ID of the item being acted upon</value>
        [JsonPropertyName("type_id")]
        public int? TypeId { get; set; }

        #endregion Properties
    }
}
