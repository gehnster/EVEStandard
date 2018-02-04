using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class Alliance
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public int CreatorId { get; set; }
        public int CreatorCorporationId { get; set; }
        public int ExecutorCorporationId { get; set; }
        public DateTime DateFounded { get; set; }
    }
}
