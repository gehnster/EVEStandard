using Microsoft.Extensions.Logging;

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
