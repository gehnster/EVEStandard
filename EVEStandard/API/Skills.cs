using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Skills : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Skills>();
        internal Skills(string dataSource) : base(dataSource)
        {
        }
    }
}
