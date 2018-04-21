using Microsoft.Extensions.Logging;


namespace EVEStandard.API
{
    public class Universe : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Universe>();
        internal Universe(string dataSource) : base(dataSource)
        {
        }
    }
}
