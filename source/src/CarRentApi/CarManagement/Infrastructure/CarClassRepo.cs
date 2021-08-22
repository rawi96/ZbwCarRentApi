using CarRentApi.Common;

namespace CarRentApi.CarManagement.Infrastructure
{
    public class CarClassRepo : BaseRepo<CarClass>
    {

        public CarClassRepo(ContextFactory contextFactory) : base(contextFactory)
        {

        }

    }
}
