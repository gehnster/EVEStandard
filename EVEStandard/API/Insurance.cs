using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Insurance : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Insurance>();
        internal Insurance(string dataSource) : base(dataSource)
        {
        }
    }
}
