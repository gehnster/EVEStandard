using Microsoft.Extensions.Logging;


namespace EVEStandard.API
{
    public class Sovereignty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Sovereignty>();
        internal Sovereignty(string dataSource) : base(dataSource)
        {
        }
    }
}
