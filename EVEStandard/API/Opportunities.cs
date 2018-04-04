using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Opportunities : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Opportunities>();
        internal Opportunities(string dataSource) : base(dataSource)
        {
        }
    }
}
