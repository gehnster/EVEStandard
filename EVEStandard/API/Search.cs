using Microsoft.Extensions.Logging;


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
