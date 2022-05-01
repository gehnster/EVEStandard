using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactorySchematic : ModelBase<FactorySchematic>
    {
        #region Properties

        /// <summary>
        /// Time in seconds to process a run
        /// </summary>
        /// <value>Time in seconds to process a run</value>
        [JsonPropertyName("cycle_time")]
        public int CycleTime { get; set; }

        /// <summary>
        /// schematic_name string
        /// </summary>
        /// <value>schematic_name string</value>
        [JsonPropertyName("schematic_name")]
        public string SchematicName { get; set; }

        #endregion Properties
    }
}
