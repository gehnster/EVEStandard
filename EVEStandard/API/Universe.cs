using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Universe : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Universe>();
        internal Universe(string dataSource) : base(dataSource)
        {
        }
    }
}
