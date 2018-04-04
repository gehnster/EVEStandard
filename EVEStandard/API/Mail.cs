using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class Mail : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Mail>();
        internal Mail(string dataSource) : base(dataSource)
        {
        }
    }
}
