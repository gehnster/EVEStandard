using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Dogma : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Dogma>();
        internal Dogma(string dataSource) : base(dataSource)
        {
        }
    }
}
