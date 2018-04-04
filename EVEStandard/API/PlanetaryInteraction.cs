using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    public class PlanetaryInteraction : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<PlanetaryInteraction>();
        internal PlanetaryInteraction(string dataSource) : base(dataSource)
        {
        }
    }
}
