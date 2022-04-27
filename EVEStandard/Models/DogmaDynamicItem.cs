using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class DogmaDynamicItem : ModelBase<DogmaDynamicItem>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the dogma attributes.
        /// </summary>
        /// <value>
        /// The dogma attributes.
        /// </value>
        [JsonPropertyName("dogma_attributes")]
        public List<DynamicItemDogmaAttribute> DogmaAttributes { get; set; }

        /// <summary>
        /// Gets or sets the dogma effects.
        /// </summary>
        /// <value>
        /// The dogma effects.
        /// </value>
        [JsonPropertyName("dogma_effects")]
        public List<DynamicItemDogmaEffect> DogmaEffects { get; set; }

        /// <summary>
        /// Gets or sets the mutator type identifier.
        /// </summary>
        /// <value>
        /// The mutator type identifier.
        /// </value>
        [JsonPropertyName("mutator_type_id")]
        public int MutatorTypeId { get; set; }

        /// <summary>
        /// Gets or sets the source type identifier.
        /// </summary>
        /// <value>
        /// The source type identifier.
        /// </value>
        [JsonPropertyName("source_type_id")]
        public int SourceTypeId { get; set; }

        #endregion
    }

    public class DynamicItemDogmaAttribute : ModelBase<DynamicItemDogmaAttribute>
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

    public class DynamicItemDogmaEffect : ModelBase<DynamicItemDogmaEffect>
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

        #endregion Properties}
    }
}
