using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Location : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Location>();
        internal Location(string dataSource) : base(dataSource)
        {
        }
    }
}
