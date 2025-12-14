using System;

namespace EVEStandard.Models.API
{
    public class APIResponse
    {
        public int MaxPages { get; set; }
        public string JSONString { get; set; }
        public bool LegacyWarning { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string ETag { get; set; }
        public bool NotModified { get; set; }
        
        // Rate limiting (floating window token bucket system)
        public string RateLimitGroup { get; set; }
        public string RateLimitLimit { get; set; }
        public int RateLimitRemaining { get; set; }
        public int RateLimitUsed { get; set; }
        public int RetryAfter { get; set; }
    }
}
