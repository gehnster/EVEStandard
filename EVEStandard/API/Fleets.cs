using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Fleets : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Fleets>();
        internal Fleets(string dataSource) : base(dataSource)
        {
        }
    }
}
