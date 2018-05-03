using System;

namespace EVEStandard.Models.API
{
    public class APIResponse
    {
        public long MaxPages { get; set; }
        public string JSONString { get; set; }
        public bool LegacyWarning { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public DateTime Expires { get; set; }
        public DateTime LastModified { get; set; }
    }
}
