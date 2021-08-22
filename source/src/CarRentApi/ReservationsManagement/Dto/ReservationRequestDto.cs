using System;

namespace CarRentApi.ReservationManagement
{
    public class ReservationRequestDto
    {
        public virtual int CustomerId { get; set; }
        public virtual int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
