using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Search : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Search>();
        internal Search(string dataSource) : base(dataSource)
        {
        }
    }
}
