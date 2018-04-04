using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class ContactLabel : ModelBase<ContactLabel>
    {
        /// <summary>
        /// label_id integer
        /// </summary>
        /// <value>label_id integer</value>
        [JsonProperty("label_id")]
        public long? LabelId { get; set; }

        /// <summary>
        /// label_name string
        /// </summary>
        /// <value>label_name string</value>
        [JsonProperty("label_name")]
        public string LabelName { get; set; }
    }
}
