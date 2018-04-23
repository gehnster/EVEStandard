using Microsoft.Extensions.Logging;


namespace EVEStandard.API
{
    public class Skills : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Skills>();
        internal Skills(string dataSource) : base(dataSource)
        {
        }
    }
}
