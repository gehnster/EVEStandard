using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Incursion : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Incursion>();
        internal Incursion(string dataSource) : base(dataSource)
        {
        }
    }
}
