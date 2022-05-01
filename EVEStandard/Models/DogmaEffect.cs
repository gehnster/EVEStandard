using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class DogmaEffect : ModelBase<DogmaEffect>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// disallow_auto_repeat boolean
        /// </summary>
        /// <value>disallow_auto_repeat boolean</value>
        [JsonPropertyName("disallow_auto_repeat")]
        public bool? DisallowAutoRepeat { get; set; }

        /// <summary>
        /// discharge_attribute_id integer
        /// </summary>
        /// <value>discharge_attribute_id integer</value>
        [JsonPropertyName("discharge_attribute_id")]
        public int? DischargeAttributeId { get; set; }

        /// <summary>
        /// display_name string
        /// </summary>
        /// <value>display_name string</value>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// duration_attribute_id integer
        /// </summary>
        /// <value>duration_attribute_id integer</value>
        [JsonPropertyName("duration_attribute_id")]
        public int? DurationAttributeId { get; set; }

        /// <summary>
        /// effect_category integer
        /// </summary>
        /// <value>effect_category integer</value>
        [JsonPropertyName("effect_category")]
        public int? EffectCategory { get; set; }

        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [JsonPropertyName("effect_id")]
        public int EffectId { get; set; }

        /// <summary>
        /// electronic_chance boolean
        /// </summary>
        /// <value>electronic_chance boolean</value>
        [JsonPropertyName("electronic_chance")]
        public bool? ElectronicChance { get; set; }

        /// <summary>
        /// falloff_attribute_id integer
        /// </summary>
        /// <value>falloff_attribute_id integer</value>
        [JsonPropertyName("falloff_attribute_id")]
        public int? FalloffAttributeId { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonPropertyName("icon_id")]
        public int? IconId { get; set; }

        /// <summary>
        /// is_assistance boolean
        /// </summary>
        /// <value>is_assistance boolean</value>
        [JsonPropertyName("is_assistance")]
        public bool? IsAssistance { get; set; }

        /// <summary>
        /// is_offensive boolean
        /// </summary>
        /// <value>is_offensive boolean</value>
        [JsonPropertyName("is_offensive")]
        public bool? IsOffensive { get; set; }

        /// <summary>
        /// is_warp_safe boolean
        /// </summary>
        /// <value>is_warp_safe boolean</value>
        [JsonPropertyName("is_warp_safe")]
        public bool? IsWarpSafe { get; set; }

        /// <summary>
        /// modifiers array
        /// </summary>
        /// <value>modifiers array</value>
        [JsonPropertyName("modifiers")]
        public List<EffectModifier> Modifiers { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// post_expression integer
        /// </summary>
        /// <value>post_expression integer</value>
        [JsonPropertyName("post_expression")]
        public int? PostExpression { get; set; }

        /// <summary>
        /// pre_expression integer
        /// </summary>
        /// <value>pre_expression integer</value>
        [JsonPropertyName("pre_expression")]
        public int? PreExpression { get; set; }
        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }
        /// <summary>
        /// range_attribute_id integer
        /// </summary>
        /// <value>range_attribute_id integer</value>
        [JsonPropertyName("range_attribute_id")]
        public int? RangeAttributeId { get; set; }

        /// <summary>
        /// range_chance boolean
        /// </summary>
        /// <value>range_chance boolean</value>
        [JsonPropertyName("range_chance")]
        public bool? RangeChance { get; set; }
        /// <summary>
        /// tracking_speed_attribute_id integer
        /// </summary>
        /// <value>tracking_speed_attribute_id integer</value>
        [JsonPropertyName("tracking_speed_attribute_id")]
        public int? TrackingSpeedAttributeId { get; set; }

        #endregion Properties
    }

    public class EffectModifier : ModelBase<EffectModifier>
    {
        #region Properties

        /// <summary>
        /// domain string
        /// </summary>
        /// <value>domain string</value>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [JsonPropertyName("effect_id")]
        public int? EffectId { get; set; }

        /// <summary>
        /// func string
        /// </summary>
        /// <value>func string</value>
        [JsonPropertyName("func")]
        public string Func { get; set; }
        /// <summary>
        /// modified_attribute_id integer
        /// </summary>
        /// <value>modified_attribute_id integer</value>
        [JsonPropertyName("modified_attribute_id")]
        public int? ModifiedAttributeId { get; set; }

        /// <summary>
        /// modifying_attribute_id integer
        /// </summary>
        /// <value>modifying_attribute_id integer</value>
        [JsonPropertyName("modifying_attribute_id")]
        public int? ModifyingAttributeId { get; set; }
        /// <summary>
        /// operator integer
        /// </summary>
        /// <value>operator integer</value>
        [JsonPropertyName("operator")]
        public int? Operator { get; set; }

        #endregion Properties
    }
}
