using CarRentApi.CarManagement;
using CarRentApi.CustomerManagement;
using System;

namespace CarRentApi.ReservationManagement
{
    public class ReservationResponseDto
    {
        public int Id { get; set; }
        public virtual CustomerResponseDto Customer { get; set; }
        public virtual CarResponseDto Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
