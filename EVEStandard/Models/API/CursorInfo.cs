using System.Text.Json.Serialization;

namespace EVEStandard.Models.API
{
    /// <summary>
    /// Cursor information for cursor-based pagination
    /// </summary>
    public class CursorInfo
    {
        /// <summary>
        /// Token to retrieve the previous page of results
        /// </summary>
        [JsonPropertyName("before")]
        public string Before { get; set; }

        /// <summary>
        /// Token to retrieve the next page of results
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; }
    }
}
