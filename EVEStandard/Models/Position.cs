using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class Position : ModelBase<Position>
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }
}
}
