using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Fittings : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Fittings>();
        internal Fittings(string dataSource) : base(dataSource)
        {
        }
    }
}
