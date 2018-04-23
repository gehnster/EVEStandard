using Microsoft.Extensions.Logging;

namespace EVEStandard.API
{
    public class Routes : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Routes>();
        internal Routes(string dataSource) : base(dataSource)
        {
        }
    }
}
