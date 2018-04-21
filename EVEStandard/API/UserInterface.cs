using Microsoft.Extensions.Logging;


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
