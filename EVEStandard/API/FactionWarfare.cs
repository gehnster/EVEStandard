using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class FactionWarfare : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<FactionWarfare>();
        internal FactionWarfare(string dataSource) : base(dataSource)
        {
        }
    }
}
