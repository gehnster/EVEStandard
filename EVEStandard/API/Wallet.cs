using Microsoft.Extensions.Logging;


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
