using AutoMapper;

namespace CarRentApi.CustomerManagement.Infrastructure
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerRequestDto>();
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<CustomerResponseDto, Customer>();
        }
    }
}
