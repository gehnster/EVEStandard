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

        [Obsolete("ESI no longer guarantees Expires is meaningful due to event-driven cache invalidation. Use CacheControlMaxAge for cache lifetime and ETag/If-None-Match to revalidate. See https://developers.eveonline.com/blog/smarter-caching-when-events-drive-invalidation")]
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }

        /// <summary>
        /// The max-age value from the response's Cache-Control header, indicating how long the
        /// response may be considered fresh. Replaces the deprecated <see cref="Expires"/> header.
        /// Null when the server did not send a Cache-Control max-age.
        /// </summary>
        public TimeSpan? CacheControlMaxAge { get; set; }
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
