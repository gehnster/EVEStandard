using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Wallet : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Wallet>();
        internal Wallet(string dataSource) : base(dataSource)
        {
        }
    }
}
