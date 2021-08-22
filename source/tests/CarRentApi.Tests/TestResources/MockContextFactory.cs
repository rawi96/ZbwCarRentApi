using CarRentApi.Common;

namespace CarRentApi.Tests.TestResources
{
    public class MockContextFactory : ContextFactory
    {
        public override Context GetNewContext()
        {
            var context = new MockContext();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
