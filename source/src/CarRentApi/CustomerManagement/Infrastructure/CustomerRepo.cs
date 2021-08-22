using CarRentApi.Common;

namespace CarRentApi.CustomerManagement.Infrastructure
{
    public class CustomerRepo : BaseRepo<Customer>
    {

        public CustomerRepo(ContextFactory contextFactory) : base(contextFactory)
        {

        }

    }
}
