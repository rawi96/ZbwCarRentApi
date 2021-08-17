using AutoMapper;
using CarRentApi.CarManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApi.Common
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            //CreateMap<Car, CarDto>()
            //    .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Type))
            //    .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Class.PricePerDay));

            //CreateMap<CarDto, Car>().ForMember(dest => dest.Class, opt => opt.Ignore());

            CreateMap<CarClass, CarClassRequestDto>();
            CreateMap<CarClass, CarClassResponseDto>();

            CreateMap<CarClassRequestDto, CarClass>();
            CreateMap<CarClassResponseDto, CarClass>();
        }
    }
}
