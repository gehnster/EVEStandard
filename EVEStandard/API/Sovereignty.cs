using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Sovereignty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Sovereignty>();
        internal Sovereignty(string dataSource) : base(dataSource)
        {
        }
    }
}
