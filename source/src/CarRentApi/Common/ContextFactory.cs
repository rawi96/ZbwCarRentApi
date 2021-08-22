namespace CarRentApi.Common
{
    public class ContextFactory
    {
        public virtual Context GetNewContext()
        {
            return new Context();
        }
    }
}
