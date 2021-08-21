using AutoMapper;

namespace CarRentApi.CarManagement.Infrastructure
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarClass, CarClassRequestDto>();
            CreateMap<CarClass, CarClassResponseDto>();
            CreateMap<CarClassRequestDto, CarClass>();
            CreateMap<CarClassResponseDto, CarClass>();

            CreateMap<Car, CarRequestDto>();
            CreateMap<Car, CarResponseDto>();
            CreateMap<CarRequestDto, Car>();
            CreateMap<CarResponseDto, Car>();
        }
    }
}
