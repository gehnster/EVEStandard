using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Type : ModelBase<Type>
    {
        #region Properties

        /// <summary>
        /// capacity number
        /// </summary>
        /// <value>capacity number</value>
        [JsonPropertyName("capacity")]
        public float? Capacity { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// dogma_attributes array
        /// </summary>
        /// <value>dogma_attributes array</value>
        [JsonPropertyName("dogma_attributes")]
        public List<UniverseDogmaAttribute> DogmaAttributes { get; set; }

        /// <summary>
        /// dogma_effects array
        /// </summary>
        /// <value>dogma_effects array</value>
        [JsonPropertyName("dogma_effects")]
        public List<UniverseDogmaEffect> DogmaEffects { get; set; }

        /// <summary>
        /// graphic_id integer
        /// </summary>
        /// <value>graphic_id integer</value>
        [JsonPropertyName("graphic_id")]
        public int? GraphicId { get; set; }

        /// <summary>
        /// group_id integer
        /// </summary>
        /// <value>group_id integer</value>
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonPropertyName("icon_id")]
        public int? IconId { get; set; }

        /// <summary>
        /// This only exists for types that can be put on the market
        /// </summary>
        /// <value>This only exists for types that can be put on the market</value>
        [JsonPropertyName("market_group_id")]
        public int? MarketGroupId { get; set; }

        /// <summary>
        /// mass number
        /// </summary>
        /// <value>mass number</value>
        [JsonPropertyName("mass")]
        public float? Mass { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// packaged_volume number
        /// </summary>
        /// <value>packaged_volume number</value>
        [JsonPropertyName("packaged_volume")]
        public float? PackagedVolume { get; set; }

        /// <summary>
        /// portion_size integer
        /// </summary>
        /// <value>portion_size integer</value>
        [JsonPropertyName("portion_size")]
        public int? PortionSize { get; set; }

        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [JsonPropertyName("published")]
        public bool Published { get; set; }

        /// <summary>
        /// radius number
        /// </summary>
        /// <value>radius number</value>
        [JsonPropertyName("radius")]
        public float? Radius { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int? TypeId { get; set; }
        /// <summary>
        /// volume number
        /// </summary>
        /// <value>volume number</value>
        [JsonPropertyName("volume")]
        public float? Volume { get; set; }

        #endregion Properties
    }

    public class UniverseDogmaAttribute : ModelBase<UniverseDogmaAttribute>
    {
        #region Properties

        /// <summary>
        /// attribute_id integer
        /// </summary>
        /// <value>attribute_id integer</value>
        [JsonPropertyName("attribute_id")]
        public int AttributeId { get; set; }

        /// <summary>
        /// value number
        /// </summary>
        /// <value>value number</value>
        [JsonPropertyName("value")]
        public float Value { get; set; }

        #endregion Properties
    }

    public class UniverseDogmaEffect : ModelBase<UniverseDogmaEffect>
    {
        #region Properties

        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [JsonPropertyName("effect_id")]
        public int EffectId { get; set; }

        /// <summary>
        /// is_default boolean
        /// </summary>
        /// <value>is_default boolean</value>
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        #endregion Properties
    }
}
