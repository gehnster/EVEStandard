using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models.API
{
    public class ESIModelDTO<T>
    {
        public T Model { get; set; }
        public bool NotModified { get; set; }
        public string ETag { get; set; }
        public string Language { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int MaxPages { get; set; }
        
        // Rate limiting (floating window token bucket system)
        public string RateLimitGroup { get; set; }
        public string RateLimitLimit { get; set; }
        public int RateLimitRemaining { get; set; }
        public int RateLimitUsed { get; set; }
        public int RetryAfter { get; set; }
        
        // Cursor-based pagination
        public CursorInfo Cursor { get; set; }
    }
}
