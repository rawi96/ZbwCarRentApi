using AutoMapper;

namespace CarRentApi.ReservationManagement.Infrastructure
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Reservation, ReservationRequestDto>();
            CreateMap<Reservation, ReservationResponseDto>();
            CreateMap<ReservationRequestDto, Reservation>();
            CreateMap<ReservationResponseDto, Reservation>();
        }
    }
}
