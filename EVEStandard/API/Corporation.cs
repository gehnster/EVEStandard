using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Corporation : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Corporation>();
        internal Corporation(string dataSource) : base(dataSource)
        {
        }
    }
}
