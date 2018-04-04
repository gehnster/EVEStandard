using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Killmails : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Killmails>();
        internal Killmails(string dataSource) : base(dataSource)
        {
        }
    }
}
