using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Routes : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Routes>();
        internal Routes(string dataSource) : base(dataSource)
        {
        }
    }
}
