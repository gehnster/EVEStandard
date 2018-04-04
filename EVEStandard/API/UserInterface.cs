using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class UserInterface : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<UserInterface>();
        internal UserInterface(string dataSource) : base(dataSource)
        {
        }
    }
}
