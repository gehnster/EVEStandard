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
        
        // Error rate limiting (tracks 4xx/5xx errors)
        public int RemainingErrors { get; set; }
        public int ErrorsTimeRemainingInWindowInSeconds { get; set; }
        
        // Request rate limiting (tracks overall request volume)
        public string RateLimitLimit { get; set; }
        public int RateLimitRemaining { get; set; }
        public int RateLimitReset { get; set; }
    }
}
