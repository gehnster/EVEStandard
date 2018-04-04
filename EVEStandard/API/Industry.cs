using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Industry : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Industry>();
        internal Industry(string dataSource) : base(dataSource)
        {
        }
    }
}
