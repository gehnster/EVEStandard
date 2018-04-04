using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Market : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Market>();
        internal Market(string dataSource) : base(dataSource)
        {
        }
    }
}
