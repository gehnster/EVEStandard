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
        public DateTime Expires { get; set; }
        public DateTime LastModified { get; set; }
        public long MaxPages { get; set; }
    }
}
