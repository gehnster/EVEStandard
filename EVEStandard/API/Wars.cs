using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Wars : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Wars>();
        internal Wars(string dataSource) : base(dataSource)
        {
        }
    }
}
